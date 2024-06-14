using UserAPI.Models;
using UserAPI.Models.Dto;
using System.Linq.Expressions;

namespace UserAPI.Repository.IRepository
{
    public interface IUserRepository : IRepository<LocalUser>
    {
        bool IsUniqueUser(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
