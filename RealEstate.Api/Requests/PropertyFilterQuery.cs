namespace RealEstate.Api.Requests;

// Esta clase se “rellena” sola desde la querystring: ?name=...&address=...&minPrice=...
public class PropertyFilterQuery
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
