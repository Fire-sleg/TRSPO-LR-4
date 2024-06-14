using AutoMapper;
using UserAPI.Data;
using UserAPI.Models;
using UserAPI.Models.Dto;
using UserAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace UserAPI.Repository
{
    public class UserRepository : Repository<LocalUser>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private string secretKey;
        public UserRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration) : base(db)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        //public async Task<LocalUser> UpdateAsync(LocalUser entity)
        //{
        //    entity.UpdatedDate = DateTime.Now;
        //    _db.Messages.Update(entity);
        //    await _db.SaveChangesAsync();
        //    return entity;
        //}
        public bool IsUniqueUser(string email)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _db.LocalUsers.FirstOrDefaultAsync(u => u.Email.ToLower() == loginRequestDTO.Email.ToLower() &&
                u.Password == loginRequestDTO.Password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };

            return loginResponseDTO;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = _mapper.Map<LocalUser>(registrationRequestDTO);
            await _db.LocalUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
