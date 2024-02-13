using WebApi.Dtos.Users;
using WebApi.Entities;

namespace WebApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<UserDto> GetById(int id);
        Task<UserDto> Update(int id, UpdateUserDto userDto);
        Task<UserDto> Delete(int id);
    }
}
