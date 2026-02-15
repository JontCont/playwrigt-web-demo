using Microsoft.AspNetCore.Mvc;
using PlaywrightWebDemo.Shared.DTOs;

namespace PlaywrightWebDemo.AdminApi.Controllers;

[ApiController]
[Route("api/admin/auth")]
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
        // TODO: Implement actual authentication logic
        if (request.Username == "admin" && request.Password == "admin")
        {
            return Ok(new { Token = "mock-jwt-token-admin", Role = "Admin" });
        }
        return Unauthorized();
    }
}
