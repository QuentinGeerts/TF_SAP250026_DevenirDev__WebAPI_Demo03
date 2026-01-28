using TodoList.Core.DTOs.Requests;
using TodoList.Core.DTOs.Responses;
using TodoList.Core.Interfaces.Repositories;
using TodoList.Core.Interfaces.Services.Auth;
using TodoList.Core.Interfaces.Services.Tools;
using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Core.Services.Auth;

public class AuthService (
    IUserRepository _userRepository,
    IPasswordHasherService _passwordHasherService,
    IJwtService _jwtService
    ) : IAuthService
{
    public async Task<LoginResponseDto> Login(LoginRequestDto credentials)
    {
        if (string.IsNullOrWhiteSpace(credentials.Email) || string.IsNullOrWhiteSpace(credentials.Password))
            throw new ArgumentException("Email et mot de passe sont requis");

        var user = await _userRepository.GetUserByEmail(credentials.Email);
        if (user == null || !_passwordHasherService.VerifyPassword(credentials.Password, user.Password))
            throw new UnauthorizedAccessException("Email ou mot de passe incorrect");

        return await _jwtService.GenerateToken(user);
    }

    public async Task<User> Register(RegisterRequestDto credentials)
    {
        var existingUser = await _userRepository.GetUserByEmail(credentials.Email);
        if (existingUser != null)
            throw new InvalidOperationException("L'email est déjà utilisée");

        var hashedPassword = _passwordHasherService.HashPassword(credentials.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = credentials.Email,
            Password = hashedPassword,
            Role = UserRole.User,
            Firstname = credentials.Firstname,
            Lastname = credentials.Lastname
        };

        return await _userRepository.AddAsync(user);
    }
}
