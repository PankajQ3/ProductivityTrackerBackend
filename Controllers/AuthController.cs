using Microsoft.AspNetCore.Mvc;
using ProductivityTrackerBackend.Services;
using ProductivityTrackerBackend.Services.Interfaces;
using ProductivityTrackerBackend.Utilities;

namespace ProductivityTrackerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserService _userService;


        public AuthController(TokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            try
            {
                // Validate the user using the UserService
                var user = await _userService.ValidateUserAsync(request.Username, request.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                // Generate the JWT token
                var token = _tokenService.GenerateToken(user.Id, user.Username);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            try
            {
                var newUser = await _userService.RegisterUserAsync(request.Username, request.Email, request.Password);
                return Ok(new { Id = newUser.Id, Username = newUser.Username, Email = newUser.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }



    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
