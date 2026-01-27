namespace TodoList.API.Extensions;

public static class CorsPolicyExtensions
{
    public static void ConfigureCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        // Récupération des origines autorisées depuis la configuration
        var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() 
            ?? throw new InvalidOperationException("Cors not configured.");

        // Configuration des CORS
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
            {
                // 1.  Pour le développement uniquement (on accepte tout) - Ne pas utiliser en production

                // policy
                //   .AllowAnyOrigin()
                //   .AllowAnyHeader()
                //   .AllowAnyMethod();


                // 2.  Configuration pour des origines spécifiques

                // policy
                //    .WithOrigins(
                //        "http://localhost:4200", // Angular
                //        "http://localhost:3000", // React
                //        "http://localhost:5500" // Javascript (LiveService
                //    )
                //    .AllowAnyHeader()
                //    .AllowAnyMethod();


                // 3.  Configuration avec une liste d'origines autorisées depuis l'appsettings (recommandé)

                policy.WithOrigins(allowedOrigins ?? Array.Empty<string>())
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
            });
        });
    }
}
