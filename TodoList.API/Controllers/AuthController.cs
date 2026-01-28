using Microsoft.AspNetCore.Mvc;
using TodoList.Core.DTOs.Requests;
using TodoList.Core.DTOs.Responses;
using TodoList.Core.Interfaces.Services.Auth;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService _authService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _authService.Register(request);

            return CreatedAtAction(
                actionName: "GetUser",
                controllerName: "Users",
                routeValues: new { id = createdUser.Id },
                value: createdUser
                );
        }
        catch (Exception ex)
        {
            return Conflict(new { ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginResponse = await _authService.Login(request);
            return Ok(loginResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

}
