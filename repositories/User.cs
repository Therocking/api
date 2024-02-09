using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Repository;
/**/
public interface IUserRepository
{
  Task<List<User>> GetAllUsers();
  Task<User?> GetOneUser(int id);
  Task<User> UpdateUser(int id, UpdateUserDto updateDto);
  Task<User> DeleteUser(int id);
}

/**/
public class UserRepository : IUserRepository
{
  private UserDb _db;

  public UserRepository(UserDb db)
  {
    _db = db;
  }

  public async Task<List<User>> GetAllUsers()
  {
    var users = await _db.Users.ToListAsync();

    return users;
  }

  public async Task<User?> GetOneUser(int id)
  {
    var user = await _db.Users.FindAsync(id);

    return user;
  }

  public async Task<User> UpdateUser(int id, UpdateUserDto updateDto)
  {
    var user = await _db.Users.FindAsync(id);

    user.Name = updateDto.Name;
    user.Pass = updateDto.Pass;

    _db.SaveChanges();

    return user;
  }

  public async Task<User> DeleteUser(int id)
  {
    var user = await _db.Users.FindAsync(id);

    _db.Remove(user);
    _db.SaveChanges();

    return user;
  }
}
