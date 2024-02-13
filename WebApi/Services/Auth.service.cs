using System.Data;
using WebApi.Dtos.Users;
using WebApi.Entities;
using WebApi.Errors;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;

namespace WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        public readonly DiccionaryMsgErrors DicErrors;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Login(LoginUserDto loginUser)
        {
            try
            {
                var user = await _repository.GetByEmail(loginUser.Email);
                if (user == null) throw HandleErrors.NotFound(DicErrors.diccionarioErrores["USER_NOT_FOUND"]);
                if (!BCrypt.Net.BCrypt.Verify(loginUser.Password, user.Password)) throw HandleErrors.BadRequest(DicErrors.diccionarioErrores["ICORRECT_PASSWORD"]);

                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age
                };
            }
            catch (Exception ex)
            {
                if (ex is HandleErrors) throw;

                throw HandleErrors.InternalError(DicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }

        public async Task<UserDto> Register(RegisterUserDto registerUser)
        {
            try
            {
                registerUser.Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);
                var user = new User
                {
                    Name = registerUser.Name,
                    Email = registerUser.Email,
                    Password = registerUser.Password,
                    Age = registerUser.Age,
                };

                await _repository.Create(user);

                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                };
            }
            catch (Exception)
            {
                throw HandleErrors.InternalError(DicErrors.diccionarioErrores["INTERNAL_ERROR"]);
            }
        }
    }
}
