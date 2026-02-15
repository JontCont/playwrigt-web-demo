using Microsoft.AspNetCore.Mvc;
using PlaywrightWebDemo.Shared.DTOs;

namespace PlaywrightWebDemo.FrontendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        // TODO: Implement actual authentication logic with JWT generation
        if (request.Username == "user" && request.Password == "password")
        {
            return Ok(new { Token = "mock-jwt-token-user", Role = "User" });
        }
        return Unauthorized();
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequestDto request)
    {
        // TODO: Implement registration logic
        return Ok(new { Message = "User registered successfully" });
    }
}
