using Moq;
using WebApi.Dtos.Users;
using WebApi.Entities;
using WebApi.Interfaces.Repositories;
using WebApi.Services;
using Xunit;

namespace Test
{
    public class UnitTest1
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
            repositoryMock.Setup(x => x.Create(It.IsAny<User>()));

            var authService = new AuthService(repositoryMock.Object);

            // Act
            var result = await authService.Register(registerUserDto);

            // Assert
            Assert.Equal(newUser.Id, result.Id);
            Assert.Equal(newUser.Name, result.Name);
            Assert.Equal(newUser.Email, result.Email);
            Assert.Equal(newUser.Age, result.Age);
        }
    }
}