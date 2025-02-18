using EcoApi.DTO;
using EcoApi.Models;

namespace EcoApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDTO> Register(UserDTO user);
        Task<UserDTO?> Login(LoginDTO user);

    }
}
