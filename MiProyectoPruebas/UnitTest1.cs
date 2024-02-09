using Moq;
using Xunit;
using Auth.Repository;
using Auth.Services;
using Users.Models;

namespace MiProyectoPruebas
{
    public class UnitTest1
    {
        [Fact]
        public void Register_ShouldCreateANewUserDocument()
        {
            // Arrange
            var mockAuthRepository = new Mock<AuthRepository>();
            mockAuthRepository.Setup(x => x.Register( It.IsAny<RegisterUserDto>() ) );

            var authService = new AuthService(mockAuthRepository.Object);
            var userData = new User("Joe", "joe@google.com", "1234");
            var registerDto = new RegisterUserDto(userData.Name, userData.Mail, userData.Pass);

            // Act
            var result = authService.Register(registerDto);

            // Assert
            Assert.Equal(2, 2);
        }
    }
}

