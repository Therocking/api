using Users.Models;
using Helpers;
using Auth.Services;

namespace Users.Controller;

public class AuthController
{
  private AuthService _service;

  public AuthController(AuthService service)
  {
    _service = service;
  }

  public async Task<IResult> Login(LoginUserDto loginDto)
  {
    try
    {
       var user = await _service.Login(loginDto);

      if(user.Pass != HashPass.GetSHA256Hash(loginDto.Pass)) return TypedResults.BadRequest("User or password incorrect");

      var userToSend = new UserDto(user);

      return TypedResults.Ok(userToSend); 
    }
    catch (System.Exception e)
    {
      if(e.ToString() == "Internal server error") return TypedResults.StatusCode(500);
      return TypedResults.NotFound(e);
    }
    
  }

  public async Task<IResult> Register(RegisterUserDto registerDto)
  {
    try
    {
        registerDto.Pass = HashPass.GetSHA256Hash(registerDto.Pass);

        var newUser = await _service.Register(registerDto);

        var user = new UserDto(newUser);

        return TypedResults.Created($"/users/{user.Id}", user);
    }
    catch (System.Exception)
    {
      return TypedResults.StatusCode(500);
    }

  }
}
