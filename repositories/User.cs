using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Repository;

public class UserRepository
{
  public async Task<List<User>> GetAllUsers(UserDb db)
  {
    var users = await db.Users.ToListAsync();

    return users;
  }

  public async Task<User?> GetOneUser(int id, UserDb db)
  {
    var user = await db.Users.FindAsync(id);

    return user;
  }

  public async Task<User> UpdateUser(int id, UpdateUserDto updateDto, UserDb db)
  {
    var user = await db.Users.FindAsync(id);

    user.Name = updateDto.Name;
    user.Pass = updateDto.Pass;

    db.SaveChanges();

    return user;
  }

  public async Task<User> DeleteUser(int id, UserDb db)
  {
    var user = await db.Users.FindAsync(id);

    db.Remove(user);
    db.SaveChanges();

    return user;
  }
}
