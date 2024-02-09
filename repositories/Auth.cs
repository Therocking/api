using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Auth.Repository;

/**/
public interface IAuthRepository
{
  Task<User> Login(LoginUserDto loginDto);
  Task<User> Register(RegisterUserDto registerDto);
}

/**/
public class AuthRepository : IAuthRepository
{
  private readonly UserDb _db;

  public AuthRepository(UserDb db)
  {
    _db = db;
  }

  public async Task<User> Login(LoginUserDto loginDto)
  {
    var user = await _db.Users
      .SingleAsync(u => u.Mail == loginDto.Mail);

    return user;
  }

  public async Task<User> Register(RegisterUserDto registerDto)
  {
    var newUser = new User(registerDto.Name, registerDto.Mail, registerDto.Pass);

    _db.Users.Add(newUser);
    await _db.SaveChangesAsync();

    return newUser;
  }
}
