using api.DTOs.UserDTOs;
using api.Mappers;
using api.Responses.UsersResponse;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "CreatedAt",
            [FromQuery] string sortOrder = "asc",
            [FromQuery] string filter = "")
        { 
            var users = await _usersService.GetPagedUsersAsync(page, pageSize, sortBy, sortOrder, filter);
            return Ok(users);
        }

        [HttpGet("get-user/{username}")]
        public async Task<IActionResult> GetUserDetailsAsync(string username)
        {
            var existingUser = await _usersService.GetUserByUsernameAsync(username);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            var toDetailsUserDTO = existingUser.ToDetailsUserDTO();

            return Ok(toDetailsUserDTO);
        }

        [HttpPut("update-user/{username}")]
        public async Task<IActionResult> UpdateUserAsync(string username, UpdateUserDTO updateUserDTO)
        {
            var updatedUser = await _usersService.GetUserByUsernameAsync(username);

            if (updatedUser == null)
            {
                return NotFound("User not found");
            }

            await _usersService.UpdateUserAsync(updatedUser, updateUserDTO);

            return Ok(new UpdateUserResponse
            {
                Username = updatedUser.UserName,
                Email = updatedUser.Email,
                UpdatedAt = updatedUser.UpdatedAt
            });
        }

        [HttpDelete("delete-user/{username}")]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            var deletedUser = await _usersService.GetUserByUsernameAsync(username);

            if (deletedUser == null)
            {
                return NotFound("User not found");
            }

            await _usersService.DeleteUserAsync(deletedUser);

            return Ok("User deleted");
        }


    }
}
