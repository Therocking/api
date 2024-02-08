using Users.Models;
using Users.Repository;

namespace Users.Services;

public class UserService
{
  private UserRepository _repository;

  public UserService(UserRepository repository) {
    _repository = repository;
  }

  public async Task<List<UserDto>> GetAll(UserDb db)
  {
    try
    {
       var users = await _repository.GetAllUsers(db);
       var userDto = users.Select(user => new UserDto(user)).ToList();
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> GetById(int id, UserDb db)
  {
    try
    {
       var user = await _repository.GetOneUser(id, db);

       if(user is null) throw new DllNotFoundException("User not found");

       var userDto = new UserDto(user);
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> Update(int id, UpdateUserDto updateDto, UserDb db)
  {
    try
    {
       var user =  await _repository.UpdateUser(id, updateDto, db);

       if(user is null) throw new DllNotFoundException("User not found");

       var userDto = new UserDto(user);
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> Delete(int id, UserDb db)
  {
    try
    {
       var user = await _repository.DeleteUser(id, db);

       if(user is null) throw new DllNotFoundException("User not found");

       var userDto = new UserDto(user);
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }
}
