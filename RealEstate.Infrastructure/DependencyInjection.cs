using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Infrastructure.Mongo;      // <-- tu settings/contexto
using RealEstate.Application.Properties;   // <-- si vas a registrar repos aquí
using RealEstate.Infrastructure.Properties;

namespace RealEstate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        // Leer la sección "Mongo" del appsettings
        var settings = cfg.GetSection("Mongo").Get<MongoSettings>()!;
        services.AddSingleton(settings);
        services.AddSingleton<MongoContext>();

        // Repositorios (si ya los tienes)
        services.AddScoped<IPropertyRepository, PropertyRepository>();

        return services;
    }
}
