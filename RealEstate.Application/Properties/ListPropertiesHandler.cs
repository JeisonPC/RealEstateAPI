namespace RealEstate.Application.Properties;

public class ListPropertiesHandler
{
    private readonly IPropertyRepository _repo;
    public ListPropertiesHandler(IPropertyRepository repo) => _repo = repo;

    public async Task<PagedResult<PropertyDto>> HandleAsync(PropertyFilterDto filter, CancellationToken ct = default)
    {
        var (items, total) = await _repo.ListAsync(filter, ct);
        return new PagedResult<PropertyDto>(
            items.Select(x => x.ToDto()).ToList(),
            filter.Page, filter.PageSize, total
        );
    }
}
