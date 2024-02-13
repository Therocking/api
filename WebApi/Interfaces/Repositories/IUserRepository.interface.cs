using WebApi.Dtos.Users;
using WebApi.Entities;

namespace WebApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task Update(int id, User user);
        Task Delete(User user);
    }
}