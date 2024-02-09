using Auth.Repository;
using Helpers;
using Users.Models;

namespace Auth.Services;

public class AuthService
{
  private IAuthRepository _repository; 

  public AuthService(IAuthRepository repository)
  {
    _repository = repository;
  }

  public async Task<User> Login(LoginUserDto loginDto)
  {
    try
    {
        var user = await _repository.Login(loginDto);

       if(user is null) throw new DllNotFoundException("User not found");

       return user;
    }
    catch (System.Exception e)
    {
      if(e.ToString() == "User not found") throw e;
      throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public async Task<User> Register(RegisterUserDto registerDto)
  {
    try
    {
        registerDto.Pass = HashPass.GetSHA256Hash(registerDto.Pass);

        var newUser = await _repository.Register(registerDto);

        return newUser;
    }
    catch (System.Exception)
    {
      throw new ArgumentException("Internal server error");
    }
  }
}
