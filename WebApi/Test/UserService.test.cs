using WebApi.Dtos.Users;
using WebApi.Entities;
using Moq.Language.Flow;
using Moq;
using Xunit;
using System.Threading.Tasks;
using WebApi.Interfaces.Repositories;
using WebApi.Services;

namespace WebApi.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async void Create_ShouldCreateANewUser()
        {
            // Arrange
            var registerUserDto = new RegisterUserDto
            {
                Name = "Test User",
                Email = "test@example.com",
                Age = 30,
                Password = "password"
            };

            var newUser = new User
            {
                Id = 1,
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                Age = registerUserDto.Age,
                Password = registerUserDto.Password
            };

            var repositoryMock = new Mock<IAuthRepository>();
            repositoryMock.Verify(x => x.Create(It.IsAny<User>()));
            //repositoryMock.Setup(repo => repo.Create(It.IsAny<User>())).ReturnsAsync(newUser);

            var userService = new AuthService(repositoryMock.Object);

            // Act
            var result = await userService.Register(registerUserDto);

            // Assert
            Assert.Equal(newUser.Id, result.Id);
            Assert.Equal(newUser.Name, result.Name);
            Assert.Equal(newUser.Email, result.Email);
            Assert.Equal(newUser.Age, result.Age);
        }
    }
}
