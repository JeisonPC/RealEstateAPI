namespace RealEstate.Domain.Entities;

public class Owner
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string? Photo { get; private set; }
    public DateOnly? Birthday { get; private set; }

    // Constructor (para crear un nuevo Owner)
    public Owner(string name, string address, string? photo = null, DateOnly? birthday = null)
    {
        Id = Guid.NewGuid().ToString(); // Generar ID único
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Name is required") : name.Trim();
        Address = string.IsNullOrWhiteSpace(address) ? throw new ArgumentException("Address is required") : address.Trim();
        Photo = string.IsNullOrWhiteSpace(photo) ? null : photo.Trim();
        Birthday = birthday;
    }

    // Constructor para reconstruir desde base de datos
    public Owner(string id, string name, string address, string? photo = null, DateOnly? birthday = null)
    {
        Id = id;
        Name = name;
        Address = address;
        Photo = photo;
        Birthday = birthday;
    }

    // Reglas de negocio
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");
        Name = name.Trim();
    }

    public void SetAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address is required");
        Address = address.Trim();
    }

    public void Update(string? name = null, string? address = null, string? photo = null, DateOnly? birthday = null)
    {
        if (name is not null) SetName(name);
        if (address is not null) SetAddress(address);
        if (photo is not null)  Photo = string.IsNullOrWhiteSpace(photo) ? null : photo.Trim();
        if (birthday.HasValue)  Birthday = birthday;
    }
}
