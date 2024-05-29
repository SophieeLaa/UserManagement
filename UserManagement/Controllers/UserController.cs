using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;

namespace UserManagement.API.Controllers
{
    
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.Identity.Name; 
            var result = await _userService.GetUserProfileAsync(userId);
            if (result == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(result);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserDTO updateUserDTO)
        {
            var userId = User.Identity.Name; 
            var result = await _userService.UpdateUserProfileAsync(userId, updateUserDTO);
            if (result == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(result);
        }
    }
}
