using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Core.Interfaces.Repositories;
using TodoList.Infrastructure.Database.Context;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Ajouter toutes les configurations liées à l'Infrastructure (ex: DbContext, Repositories, etc.)
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<TodoListContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}
