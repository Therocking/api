using WebApi.Dtos.Users;
using WebApi.Entities;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;

namespace WebApi.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public  async Task<UserDto> Create(RegisterUserDto userDto)
        {
            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Age = userDto.Age,
                Password = userDto.Password,
            };

            await _repository.Create(newUser);

            return new UserDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Age = newUser.Age,
            };
        }

        public async Task<UserDto> Delete(int id)
        {
            var user = await _repository.GetById(id);

            await _repository.Delete(user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
            };
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _repository.GetAll();

            return users;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _repository.GetById(id);

            return new UserDto
            {
                Id = id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
            };
        }

        public async Task<UserDto> Update(int id, UpdateUserDto userDto)
        {
            var user = await _repository.GetById(id);

            await _repository.Update(id, user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
            };
        }
    }
}
