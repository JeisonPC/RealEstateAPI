using RealEstate.Domain.Entities;

namespace RealEstate.Application.Properties;

public interface IPropertyRepository
{
    Task<Property?> GetByIdAsync(string id, CancellationToken ct = default);

    // Devuelve entidades de dominio y el total (para paginar)
    Task<(IReadOnlyList<Property> Items, long Total)> ListAsync(
        PropertyFilterDto filter, CancellationToken ct = default);
}
