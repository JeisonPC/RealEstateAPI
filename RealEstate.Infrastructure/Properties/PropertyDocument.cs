using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstate.Infrastructure.Properties;

public class PropertyDocument
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdOwner { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public decimal Price { get; set; }
    public string CodeInternal { get; set; } = null!;
    public int Year { get; set; }
}
