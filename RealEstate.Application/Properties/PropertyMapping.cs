using RealEstate.Domain.Entities;

namespace RealEstate.Application.Properties;

public static class PropertyMapping
{
    public static PropertyDto ToDto(this Property p) =>
        new(p.Id, p.IdOwner, p.Name, p.Address, p.Price, p.ImageUrl);
}
