using Microsoft.AspNetCore.Mvc;
using OnlineForestAPI.DTO;
using OnlineForestAPI.Interfaces;

namespace OnlineForestAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var user = await _authService.RegisterAsync(request.Username, request.Password, request.Email);
                return Ok(new { Message = "Successful registration!", UserId = user.UserId });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var user = await _authService.LoginAsync(request.Username, request.Password);
                return Ok(new { Message = "Sign in successfully!", UserId = user.UserId });
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
