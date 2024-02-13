using WebApi.Dtos.Users;
using WebApi.Entities;
using WebApi.Errors;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;

namespace WebApi.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        public readonly DiccionaryMsgErrors dicErrors = new DiccionaryMsgErrors(); 

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Delete(int id)
        {
            try
            {
                var user = await _repository.GetById(id);
                if (user is null) throw HandleErrors.NotFound(dicErrors.diccionarioErrores["USER_NOT_FOUND"]);

                await _repository.Delete(user);

                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                };
            }
            catch (Exception ex)
            {
                if(ex is HandleErrors) throw;

                throw HandleErrors.InternalError(dicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var users = await _repository.GetAll();

                return users;
            }
            catch (Exception)
            {
                throw HandleErrors.InternalError(dicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }

        public async Task<UserDto> GetById(int id)
        {
            try
            {
                var user = await _repository.GetById(id);
                if (user is null) throw HandleErrors.NotFound(dicErrors.diccionarioErrores["USER_NOT_FOUND"]);

                return new UserDto
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                };
            }
            catch (Exception ex)
            {
                if(ex is HandleErrors) throw;

                throw HandleErrors.InternalError(dicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }

        public async Task<UserDto> Update(int id, UpdateUserDto userDto)
        {
            try
            {
                var user = await _repository.GetById(id);
                if (user is null) throw HandleErrors.NotFound(dicErrors.diccionarioErrores["USER_NOT_FOUND"]);

                await _repository.Update(id, user);

                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                };
            }
            catch (Exception ex)
            {
                if (ex is HandleErrors) throw;

                throw HandleErrors.InternalError(dicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }
    }
}
