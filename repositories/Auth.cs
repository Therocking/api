using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Auth.Repository;

public class AuthRepository
{
  public async Task<User> Login(LoginUserDto loginDto, UserDb db)
  {
    var user = await db.Users
      .SingleAsync(u => u.Mail == loginDto.Mail);

    return user;
  }

  public async Task<User> Register(RegisterUserDto registerDto, UserDb db)
  {
    var newUser = new User(registerDto.Name, registerDto.Mail, registerDto.Pass);

    db.Users.Add(newUser);
    await db.SaveChangesAsync();

    return newUser;
  }
}
