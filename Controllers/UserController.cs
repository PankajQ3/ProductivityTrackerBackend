using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTrackerBackend.Models;
using ProductivityTrackerBackend.Services.Interfaces;

namespace ProductivityTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get a specific user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            //var user = await _userService.GetByIdAsync(id);
            //if (user == null) return NotFound();
            //return Ok(user);
            return Ok();
        }


        // Create a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // Update an existing user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest();

            var success = await _userService.UpdateUserAsync(user);
            if (!success) return NotFound();

            return NoContent();
        }

        // Delete a user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }

}
