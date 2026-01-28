using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Interfaces.Services;
using TodoList.Core.Interfaces.Services.Auth;
using TodoList.Core.Interfaces.Services.Tools;
using TodoList.Core.Services.Auth;
using TodoList.Core.Services.Data;
using TodoList.Core.Services.Tools;

namespace TodoList.Core;

public static class ServiceExtensions
{
    public static void ConfigureCore(this IServiceCollection services)
    {
        // Ajouter toutes les configurations liées au Core (ex: Services, etc.)
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IJwtService, JwtService>();
    }
}
