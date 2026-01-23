using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services.Auth;

public interface IAuthService
{
    Task<User> Register(string email, string password);
}
