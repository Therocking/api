using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Controller;

public class UserController
{
  public static async Task<IResult> GetAll(UserDb db)
  {
    var users = await db.Users.Select(x => new UserDto(x)).ToListAsync();
    return TypedResults.Ok(users);
  }

  public static async Task<IResult> GetById(int id, UserDb db)
  {
    return await db.Users.FindAsync(id)
      is User user
        ? TypedResults.Ok(new UserDto(user))
        : TypedResults.NotFound();
  }

  public static async Task<IResult> Update(int id, UpdateUserDto updateDto, UserDb db)
  {
    var user = await db.Users.FindAsync(id);

    if(user is null) return TypedResults.NotFound();
    
    user.Name = updateDto.Name;
    user.Pass = updateDto.Pass;

    await db.SaveChangesAsync();

    return TypedResults.NoContent();
  }

  public static async Task<IResult> Delete(int id, UserDb db)
  {
    var user = await db.Users.FindAsync(id);

    if(user is null) return TypedResults.NotFound();

    db.Remove(user);
    await db.SaveChangesAsync();

    return TypedResults.NoContent();
  }
}
