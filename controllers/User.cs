using Users.Models;
using Users.Services;

namespace Users.Controller;

public class UserController
{
  private UserService _service;

  public UserController(UserService service) {
    _service = service;
  }

  public  async Task<IResult> GetAll(UserDb db)
  {
    try
    {
      var user = await _service.GetAll(db);
      return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> GetById(int id, UserDb db)
  {
    try
    {
       var user = await _service.GetById(id, db);

       return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
        return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> Update(int id, UpdateUserDto updateDto, UserDb db)
  {
    try
    {
       var user =  await _service.Update(id, updateDto, db);

      return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> Delete(int id, UserDb db)
  {
    try
    {
       var user = await _service.Delete(id, db);

      return TypedResults.Ok(user); 
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }

  }
}
