using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using UserAPI.Models;
using UserAPI.Models.Dto;
using UserAPI.Repository.IRepository;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace UserAPI.Controllers
{
    [Route("api/v{version:apiVersion}/Users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        protected APIResponse _response;
        private readonly IUserRepository _dbUser;
        private readonly IMapper _mapper;

        public UserController(IUserRepository dbUser, IMapper mapper)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
            _dbUser = dbUser;
            _mapper = mapper;
            _response = new();
        }

        [Authorize]
        [HttpGet("getProducts")]
        public async Task<ActionResult<APIResponse>> GetAllProductsAsync()
        {
            try
            {

                string apiUrl = "https://host.docker.internal:6060/api/v1/Products/products";
                
                var response = await _httpClient.GetStreamAsync(apiUrl);
                var res = new StreamReader(response);
                var result = await res.ReadToEndAsync(); 

                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                var apiResponse = JsonSerializer.Deserialize<APIResponse>(result, options);

                string json = apiResponse.Result.ToString();
                int index = json.IndexOf('[');
                if (index >= 0)
                {
                    json = json.Substring(index);
                }
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);


                var productsDTO = _mapper.Map<List<ProductDTO>>(products);

                return Ok(new APIResponse
                {
                    Result = productsDTO,
                    StatusCode = HttpStatusCode.OK,
                    IsSuccess = true
                });
               
            }
            catch (HttpRequestException ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorsMessages.Add(ex.Message);
                _response.IsSuccess = false;
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorsMessages.Add(ex.Message);
                _response.IsSuccess = false;
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }
        [Authorize]
        [HttpPost("getRecipes")]
        public async Task<ActionResult<APIResponse>> GetRecipesForProducts([FromBody] List<Guid> selectedProducts)
        {
            string apiUrl = "https://host.docker.internal:6061/api/v1/Recipes/recommendations";

            var requestDataJson = JsonConvert.SerializeObject(selectedProducts);

            var content = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);


            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<APIResponse>(responseContent);

            string json = apiResponse.Result.ToString();
            int index = json.IndexOf('[');
            if (index >= 0)
            {
                json = json.Substring(index);
            }

            List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);


            var recipesDTO = _mapper.Map<List<RecipeDTO>>(recipes);

            return Ok(new APIResponse
            {
                Result = recipesDTO,
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _dbUser.Login(model);
            if (loginResponse == null || loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add("Email or password is incorrect");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            bool ifUserEmailUnique = _dbUser.IsUniqueUser(model.Email);
            if (!ifUserEmailUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add("Email is already exists");
                return BadRequest(_response);
            }
            var user = await _dbUser.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add("Error while registering");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            //_response.Result = user;
            return Ok(_response);
        }
    }
}
