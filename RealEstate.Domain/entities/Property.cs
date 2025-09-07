namespace RealEstate.Domain.Entities;

public class Property
{
    public string Id { get; }
    public string IdOwner { get; }
    public string Name { get; }
    public string Address { get; }
    public decimal Price { get; }
    public string? ImageUrl { get; }

    public Property(string id, string idOwner, string name, string address, decimal price, string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(idOwner)) throw new ArgumentException("IdOwner required");
        if (string.IsNullOrWhiteSpace(name))    throw new ArgumentException("Name required");
        if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address required");
        if (price < 0)                           throw new ArgumentException("Price >= 0");

        Id = id; IdOwner = idOwner.Trim(); Name = name.Trim(); Address = address.Trim();
        Price = price; ImageUrl = string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl.Trim();
    }
}
