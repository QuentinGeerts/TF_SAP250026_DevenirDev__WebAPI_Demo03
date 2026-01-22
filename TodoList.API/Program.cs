using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoList.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Ajout de la connectionString via l'injection de dépendance
// => L'instance de TodoList sera fournie dans le constructeur de la classe qui a
// besoin de TodoListContext avec la configuration du provider + connectionString
builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Gestion des cors
builder.Services.AddCors(options =>
{
    // Configuration des CORS

    // Pour le développement uniquement
    //options.AddDefaultPolicy(policy => 
    //    policy
    //        .AllowAnyOrigin()
    //        .AllowAnyHeader()
    //        .AllowAnyMethod());

    //options.AddDefaultPolicy(policy =>
    //    policy
    //        .WithOrigins(
    //            "http://localhost:4200", // Angular
    //            "http://localhost:3000", // React
    //            "http://localhost:5500" // Javascript (LiveService
    //        )
    //        .AllowAnyHeader()
    //        .AllowAnyMethod());

    // Avec une configuration dans le appsettings

    var allowedOrigins = builder.Configuration
        .GetSection("Cors:AllowedOrigins")
        .Get<string[]>() ?? throw new InvalidOperationException("Cors not configured.");

    options.AddDefaultPolicy(policy =>
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors(); // Permet d'utiliser les CORS

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => new { message = "Coucou" });

app.Run();
