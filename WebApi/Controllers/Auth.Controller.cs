using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.Users;
using WebApi.Errors;
using WebApi.Interfaces.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            try
            {
                var user = await _service.Login(loginUser);
                return Ok(user);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser)
        {
            try
            {
                var user = await _service.Register(registerUser);
                return Ok(user);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }
    }
}
