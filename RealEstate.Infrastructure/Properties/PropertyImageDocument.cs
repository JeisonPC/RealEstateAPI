using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealEstate.Infrastructure.Properties;

public class PropertyImageDocument
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; } = null!;
    public string File { get; set; } = null!;
    public bool Enabled { get; set; }
}
