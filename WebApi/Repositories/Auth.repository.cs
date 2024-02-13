using WebApi.Entities;
using WebApi.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiContext _db;

        public AuthRepository(ApiContext db)
        {
            _db = db;
        }

        public async Task Create(User user)
        {
           await _db.AddAsync(user);
           await _db.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _db.User.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
