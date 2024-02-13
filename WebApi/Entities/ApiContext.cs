using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
