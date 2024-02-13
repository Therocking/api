using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos.Users;
using WebApi.Errors;
using WebApi.Interfaces.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _service.GetAll();

                return Ok(users);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _service.GetById(id);

                return Ok(user);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto updateDto)
        {
            try
            {
                var user = await _service.Update(id, updateDto);

                return Ok(user);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _service.Delete(id);

                return Ok(user);
            }
            catch (HandleErrors ex)
            {
                return StatusCode(ex.StatusCode, ex.Msg);
            }
        }
    }
}
