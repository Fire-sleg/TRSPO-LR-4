using AutoMapper;
using RecipeAPI.Data;
using RecipeAPI.Models;
using RecipeAPI.Models.Dto;
using RecipeAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace RecipeAPI.Controllers
{
    [Route("api/v{version:apiVersion}/Recipes")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class RecipeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IRecipeRepository _dbRecipe;
        private readonly IMapper _mapper;
        public RecipeController(IRecipeRepository dbRecipe, IMapper mapper)
        {
            _dbRecipe = dbRecipe;
            _mapper = mapper;
            _response = new ();
        }
        
        [HttpGet("recipes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetRecipesAsync()
        {
            try
            {
                IEnumerable<Recipe> RecipeList = await _dbRecipe.GetAllAsync();
                _response.Result = _mapper.Map<List<RecipeDTO>>(RecipeList);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorsMessages.Add(ex.ToString());
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response); 
            
        }


        [HttpGet("{id:Guid}", Name = "GetRecipe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAsync(Guid id)
        {
            try
            {
                if (id == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var recipe = await _dbRecipe.GetAsync(u => u.Id == id);
                _response.Result = _mapper.Map<RecipeDTO>(recipe);
                if (recipe != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add(ex.ToString() );
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);

        }
        [HttpPost("recommendations")]
        public async Task<ActionResult<APIResponse>> GetRecommendations([FromBody] List<Guid> productIds)
        {
            try
            {
                if (productIds == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                //IEnumerable<Recipe> recipeList = await _dbRecipe.GetAllAsync(u => u.ProductIds.Intersect(productIds).Any());
                IEnumerable<Recipe> recipeList = await _dbRecipe.GetAllAsync(u => u.ProductIds.All(id => productIds.Contains(id)));
                _response.Result = _mapper.Map<List<RecipeDTO>>(recipeList);
                if (recipeList != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add(ex.ToString());
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }

        //[MapToApiVersion("2.0")]
        //[HttpGet("send/{senderId:int}", Name = "GetUserSendMessages")]


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateRecipeAsync([FromBody] RecipeCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Result = createDTO;
                    return BadRequest(_response);
                }

                /*User Reposetory need to change to db or user manager*/
                //var senderExists = _dbUser.GetAsync(u => u.Id == createDTO.SenderId);
                //var receiverExists = _dbUser.GetAsync(u => u.Id == createDTO.ReceiverId);
                /**/
                /*
                if (senderExists == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorsMessages.Add("Sender does not exist.");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                if (receiverExists == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorsMessages.Add("Receiver does not exist.");
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                */

                Recipe model = _mapper.Map<Recipe>(createDTO);

                await _dbRecipe.CreateAsync(model);

                _response.Result = _mapper.Map<RecipeDTO>(model); ;
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true; 

                return CreatedAtRoute("GetRecipe", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add(ex.ToString());
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);

        }

        [HttpDelete("{id:Guid}", Name = "DeleteRecipe")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMessageAsync(Guid id)
        {
            try
            {
                if (id == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var recipe = await _dbRecipe.GetAsync(u => u.Id == id);
                if (recipe == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound; 
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbRecipe.RemoveAsync(recipe);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.ToString() };
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);

        }

        [HttpPut("{id:Guid}", Name = "UpdateRecipe")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateRecipeAsync(Guid id, [FromBody] RecipeUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                //var message = MessageRepository.messageList.FirstOrDefault(u => u.Id == id);

                //message.Content = messageDTO.Content;
                Recipe model = _mapper.Map<Recipe>(updateDTO);

                await _dbRecipe.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages.Add(ex.ToString() );
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
            
        }

        [HttpPatch("{id:Guid}", Name = "UpdatePartialRecipe")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialMessageAsync(Guid id, JsonPatchDocument<RecipeUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            /*---AsNoTracking()---*/
            var recipe = await _dbRecipe.GetAsync(u => u.Id == id, tracked:false);

            RecipeUpdateDTO recipeDTO = _mapper.Map<RecipeUpdateDTO>(recipe);

            if (recipe == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            patchDTO.ApplyTo(recipeDTO, ModelState);

            Recipe model = _mapper.Map<Recipe>(recipeDTO);


            await _dbRecipe.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        
    }
}
