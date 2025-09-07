namespace RealEstate.Infrastructure.Mongo;

public class MongoSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string PropertiesCollection { get; set; } = null!;
    public string PropertyImagesCollection { get; set; } = null!;
}
