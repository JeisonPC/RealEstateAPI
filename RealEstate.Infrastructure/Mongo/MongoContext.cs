using MongoDB.Driver;

namespace RealEstate.Infrastructure.Mongo;

public class MongoContext
{
    public IMongoDatabase Db { get; }

    public MongoContext(MongoSettings settings)
    {
        // Configurar las opciones del cliente MongoDB con SSL
        var clientSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);
        
        // Configuración específica para SSL en contenedores Linux
        clientSettings.SslSettings = new SslSettings
        {
            EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
        };
        
        // Configurar timeouts
        clientSettings.ConnectTimeout = TimeSpan.FromSeconds(30);
        clientSettings.ServerSelectionTimeout = TimeSpan.FromSeconds(30);
        
        var client = new MongoClient(clientSettings);
        Db = client.GetDatabase(settings.Database);
    }
}
