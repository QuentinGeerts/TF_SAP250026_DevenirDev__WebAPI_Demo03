using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.DTOs.Requests;
using TodoList.Core.Interfaces.Services;
using TodoList.Core.Interfaces.Services.Auth;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IAuthService _authService,
    IUserService _userService
    ) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register (RegisterRequestDto request)
    {
		try
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdUser = await _authService.Register(request.Email, request.Password);
            createdUser.Lastname = request.Lastname;
            createdUser.Firstname = request.Firstname;

            await _userService.UpdateAsync(createdUser.Id, createdUser);
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

}
