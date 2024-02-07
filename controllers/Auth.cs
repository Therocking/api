using Microsoft.EntityFrameworkCore;
using Users.Models;
using Helpers;

namespace Users.Controller;

public class AuthController
{
  public static async Task<IResult> Login(LoginUserDto loginDto, UserDb db)
  {
    var user = await db.Users
      .SingleAsync(u => u.Mail == loginDto.Mail);

    if(user is null) return TypedResults.NotFound("User or password incorrect");

    if(user.Pass != HashPass.GetSHA256Hash(loginDto.Pass)) return TypedResults.BadRequest("User or password incorrect");

    var userToSend = new UserDto(user);

    return TypedResults.Ok(userToSend);
  }

  public static async Task<IResult> Register(RegisterUserDto registerDto, UserDb db)
  {
    var passHashed = HashPass.GetSHA256Hash(registerDto.Pass);

    var newUser = new User(registerDto.Name, registerDto.Mail, passHashed);

    db.Users.Add(newUser);
    await db.SaveChangesAsync();

    var user = new UserDto(newUser);

    return TypedResults.Created($"/users/{user.Id}", user);
  }
}
