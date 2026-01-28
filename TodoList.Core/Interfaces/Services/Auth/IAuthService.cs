using TodoList.Core.DTOs.Requests;
using TodoList.Core.DTOs.Responses;
using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services.Auth;

public interface IAuthService
{
    Task<User> Register(RegisterRequestDto credentials);
    Task<LoginResponseDto> Login(LoginRequestDto credentials);
}
