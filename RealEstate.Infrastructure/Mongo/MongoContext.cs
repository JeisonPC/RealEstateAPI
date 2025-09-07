using MongoDB.Driver;

namespace RealEstate.Infrastructure.Mongo;

public class MongoContext
{
    public IMongoDatabase Db { get; }

    public MongoContext(MongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        Db = client.GetDatabase(settings.Database);
    }
}
