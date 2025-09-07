using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealEstate.Infrastructure.Mongo;      // <-- tu settings/contexto
using RealEstate.Application.Properties;   // <-- si vas a registrar repos aquí
using RealEstate.Infrastructure.Properties;

namespace RealEstate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        // Leer la sección "Mongo" del appsettings
        var settings = cfg.GetSection("Mongo").Get<MongoSettings>();
        
        if (settings == null)
        {
            throw new InvalidOperationException("MongoDB settings not found in configuration. Make sure 'Mongo' section exists.");
        }
        
        if (string.IsNullOrEmpty(settings.ConnectionString))
        {
            throw new InvalidOperationException("MongoDB ConnectionString is not configured. Make sure 'Mongo:ConnectionString' is set.");
        }
        
        services.AddSingleton(settings);
        services.AddSingleton<MongoContext>();

        // Repositorios (si ya los tienes)
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        return services;
    }
}
