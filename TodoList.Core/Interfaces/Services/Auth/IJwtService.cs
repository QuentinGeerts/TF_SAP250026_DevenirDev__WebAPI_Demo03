using TodoList.Core.DTOs.Responses;
using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services.Auth;

public interface IJwtService
{
    Task<LoginResponseDto> GenerateToken(User user);
}
