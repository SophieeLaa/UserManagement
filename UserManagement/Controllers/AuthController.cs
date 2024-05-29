using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;

namespace UserManagement.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var result = await _userService.RegisterUserAsync(registerDTO);
            if (result == null)
            {
                return BadRequest("User registration failed.");
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _userService.LoginAsync(loginDTO);
            if (result == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(result);
        }
    }
}
