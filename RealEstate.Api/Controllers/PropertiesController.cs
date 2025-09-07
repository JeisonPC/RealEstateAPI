using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Properties;
using RealEstate.Api.Requests;

namespace RealEstate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly GetPropertyHandler _getHandler;
    private readonly ListPropertiesHandler _listHandler;

    public PropertiesController(GetPropertyHandler getHandler, ListPropertiesHandler listHandler)
    {
        _getHandler = getHandler;
        _listHandler = listHandler;
    }

    /// <summary>
    /// Obtiene todas las propiedades con filtros opcionales
    /// </summary>
    /// <param name="query">Filtros de búsqueda y paginación</param>
    /// <param name="ct">Token de cancelación</param>
    /// <returns>Lista paginada de propiedades</returns>
    [HttpGet]
    public async Task<ActionResult<PagedResult<PropertyDto>>> ListProperties(
        [FromQuery] PropertyFilterQuery query,
        CancellationToken ct)
    {
        var filter = new PropertyFilterDto(
            query.Name, 
            query.Address, 
            query.MinPrice, 
            query.MaxPrice, 
            query.Page, 
            query.PageSize);
            
        var result = await _listHandler.HandleAsync(filter, ct);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene una propiedad específica por su ID
    /// </summary>
    /// <param name="id">ID de la propiedad</param>
    /// <param name="ct">Token de cancelación</param>
    /// <returns>Detalles de la propiedad</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyDto>> GetProperty(string id, CancellationToken ct)
    {
        var dto = await _getHandler.HandleAsync(id, ct);
        return dto is null ? NotFound() : Ok(dto);
    }
}
