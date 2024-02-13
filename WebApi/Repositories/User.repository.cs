using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Interfaces.Repositories;

namespace WebApi.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApiContext _db;

        public UserRepository(ApiContext db)
        {
            _db = db;
        }

        public async Task Delete(User user)
        {
            _db.User.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _db.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _db.User.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(int id, User userData)
        {
            var user = await GetById(id);

            user.Name = userData.Name;
            user.Age = userData.Age;
            user.Password = userData.Password;

            await _db.SaveChangesAsync();
        }
    }
}
