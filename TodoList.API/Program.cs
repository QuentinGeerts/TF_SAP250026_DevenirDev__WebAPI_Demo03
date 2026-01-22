using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

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
