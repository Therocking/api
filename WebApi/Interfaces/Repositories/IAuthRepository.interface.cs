using WebApi.Dtos.Users;
using WebApi.Entities;

namespace WebApi.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetByEmail(string email);
        Task Create(User user);
    }
}
