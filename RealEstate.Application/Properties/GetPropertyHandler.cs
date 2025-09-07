namespace RealEstate.Application.Properties;

public class GetPropertyHandler
{
    private readonly IPropertyRepository _repo;
    public GetPropertyHandler(IPropertyRepository repo) => _repo = repo;

    public async Task<PropertyDto?> HandleAsync(string id, CancellationToken ct = default)
        => (await _repo.GetByIdAsync(id, ct))?.ToDto();
}
