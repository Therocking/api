using Auth.Repository;
using Users.Models;

namespace Auth.Services;

public class AuthService
{
  private AuthRepository _repository; 

  public AuthService(AuthRepository repository)
  {
    _repository = repository;
  }

  public async Task<User> Login(LoginUserDto loginDto, UserDb db)
  {
    try
    {
        var user = await _repository.Login(loginDto, db);

       if(user is null) throw new DllNotFoundException("User not found");

       return user;
    }
    catch (System.Exception e)
    {
      if(e.ToString() == "User not found") throw e;
      throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public async Task<User> Register(RegisterUserDto registerDto, UserDb db)
  {
    try
    {
        var newUser = new User(registerDto.Name, registerDto.Mail, registerDto.Pass);

        db.Users.Add(newUser);
        await db.SaveChangesAsync();
        return newUser;
    }
    catch (System.Exception)
    {
      throw new ArgumentException("Internal server error");
    }
  }
}
