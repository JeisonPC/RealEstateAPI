using MongoDB.Bson;
using MongoDB.Driver;
using RealEstate.Application.Properties;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Mongo;

namespace RealEstate.Infrastructure.Properties;

public class PropertyRepository : IPropertyRepository
{
    private readonly IMongoCollection<PropertyDocument> _props;
    private readonly IMongoCollection<PropertyImageDocument> _imgs;

    public PropertyRepository(MongoContext ctx, MongoSettings s)
    {
        _props = ctx.Db.GetCollection<PropertyDocument>(s.PropertiesCollection);
        _imgs  = ctx.Db.GetCollection<PropertyImageDocument>(s.PropertyImagesCollection);
    }

    public async Task<Property?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var prop = await _props.Find(p => p.Id == id).FirstOrDefaultAsync(ct);
        if (prop is null) return null;

        var imageUrl = await _imgs
            .Find(i => i.IdProperty == id && i.Enabled)
            .Project(i => i.File)
            .FirstOrDefaultAsync(ct);

        return new Property(prop.Id, prop.IdOwner, prop.Name, prop.Address, prop.Price, imageUrl);
    }

    public async Task<(IReadOnlyList<Property> Items, long Total)> ListAsync(
        PropertyFilterDto f, CancellationToken ct = default)
    {
        var fb = Builders<PropertyDocument>.Filter;
        var filters = new List<FilterDefinition<PropertyDocument>>();

        if (!string.IsNullOrWhiteSpace(f.Name))
            filters.Add(fb.Regex(x => x.Name, new BsonRegularExpression(f.Name, "i")));

        if (!string.IsNullOrWhiteSpace(f.Address))
            filters.Add(fb.Regex(x => x.Address, new BsonRegularExpression(f.Address, "i")));

        if (f.MinPrice is not null)
            filters.Add(fb.Gte(x => x.Price, f.MinPrice.Value));

        if (f.MaxPrice is not null)
            filters.Add(fb.Lte(x => x.Price, f.MaxPrice.Value));

        var match = filters.Count > 0 ? fb.And(filters) : FilterDefinition<PropertyDocument>.Empty;

        // Total antes de paginar
        var total = await _props.CountDocumentsAsync(match, cancellationToken: ct);

        // Paginación
        var skip = f.Page <= 1 ? 0 : (f.Page - 1) * f.PageSize;

        // Traemos la “primera imagen enabled” por propiedad con dos consultas simples:
        var docs = await _props.Find(match)
            .SortBy(x => x.Name).ThenBy(x => x.Id)
            .Skip(skip).Limit(f.PageSize)
            .ToListAsync(ct);

        var results = new List<Property>(docs.Count);

        foreach (var d in docs)
        {
            var imgUrl = await _imgs
                .Find(i => i.IdProperty == d.Id && i.Enabled)
                .Project(i => i.File)
                .FirstOrDefaultAsync(ct);

            results.Add(new Property(d.Id, d.IdOwner, d.Name, d.Address, d.Price, imgUrl));
        }

        return (results, total);
    }
}
