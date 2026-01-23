using TodoList.Core.Interfaces.Repositories;
using TodoList.Core.Interfaces.Services.Auth;
using TodoList.Core.Interfaces.Services.Tools;
using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Core.Services.Auth;

public class AuthService (
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService
    ) : IAuthService
{
    public async Task<User> Register(string email, string password)
    {
        var existingUser = await _userRepository.GetUserByEmail(email);
        if (existingUser != null)
            throw new InvalidOperationException("L'email est déjà utilisée");

        var hashedPassword = _passwordHasherService.HashPassword(password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = hashedPassword,
            Role = UserRole.User
        };

        return await _userRepository.AddAsync(user);
    }
}
