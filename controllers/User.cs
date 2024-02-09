using Users.Models;
using Users.Services;

namespace Users.Controller;

public class UserController
{
  private UserService _service;

  public UserController(UserService service) {
    _service = service;
  }

  public async Task<IResult> GetAll()
  {
    try
    {
      var user = await _service.GetAll();
      return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> GetById(int id)
  {
    try
    {
       var user = await _service.GetById(id);

       return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
        return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> Update(int id, UpdateUserDto updateDto)
  {
    try
    {
       var user =  await _service.Update(id, updateDto);

      return TypedResults.Ok(user);
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }
  }

  public  async Task<IResult> Delete(int id)
  {
    try
    {
       var user = await _service.Delete(id);

      return TypedResults.Ok(user); 
    }
    catch (System.Exception e)
    {
      return TypedResults.NotFound(e);
    }

  }
}
