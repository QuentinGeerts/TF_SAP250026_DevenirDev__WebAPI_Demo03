using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoList.API.Extensions;
using TodoList.Core;
using TodoList.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuration du Core et Infrastructure (méthodes d'extension)
builder.Services.ConfigureCore();
builder.Services.ConfigureInfrastructure(builder.Configuration);

// Configuration des cors
builder.Services.ConfigureCorsPolicy(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy"); // Permet d'utiliser les CORS
app.UseAuthorization();
app.MapControllers();

app.Run();
