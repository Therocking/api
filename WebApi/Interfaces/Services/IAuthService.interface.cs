using WebApi.Dtos.Users;

namespace WebApi.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserDto> Login(LoginUserDto loginUser);
        Task<UserDto> Register(RegisterUserDto registerUser);
    }
}
