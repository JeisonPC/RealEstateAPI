namespace RealEstate.Application.Properties;

// Lo que devolverá la API (lo que el frontend necesita)
public record PropertyDto(
    string Id,        // _id de Mongo en texto
    string IdOwner,   // referencia al dueño
    string Name,
    string Address,
    decimal Price,
    string? ImageUrl  // UNA imagen (o null si no hay)
);

// Filtros de búsqueda + paginación
public record PropertyFilterDto(
    string? Name,
    string? Address,
    decimal? MinPrice,
    decimal? MaxPrice,
    int Page = 1,
    int PageSize = 20
);

// Envoltorio de respuesta paginada
public record PagedResult<T>(
    IReadOnlyList<T> Items, int Page, int PageSize, long Total
);
