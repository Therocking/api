using Users.Models;
using Users.Repository;

namespace Users.Services;

public class UserService
{
  private IUserRepository _repository;

  public UserService(IUserRepository repository) {
    _repository = repository;
  }

  public async Task<List<UserDto>> GetAll()
  {
    try
    {
       var users = await _repository.GetAllUsers();
       var userDto = users.Select(user => new UserDto(user)).ToList();
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> GetById(int id)
  {
    try
    {
       var user = await _repository.GetOneUser(id);

       if(user is null) throw new DllNotFoundException("User not found");

       var userDto = new UserDto(user);
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> Update(int id, UpdateUserDto updateDto)
  {
    try
    {
       var user =  await _repository.UpdateUser(id, updateDto);

       if(user is null) throw new DllNotFoundException("User not found");

       var userDto = new UserDto(user);
       return userDto;
    }
    catch (System.Exception)
    {
        throw new ArgumentException("Internal server error. Try later.");
    }
  }

  public  async Task<UserDto> Delete(int id)
  {
    try
    {
       var user = await _repository.DeleteUser(id);

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
