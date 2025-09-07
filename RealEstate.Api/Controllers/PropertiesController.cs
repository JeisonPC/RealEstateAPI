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
    /// Endpoint simple para verificar que el controlador funciona
    /// </summary>
    /// <returns>Mensaje de estado</returns>
    [HttpGet("health")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public IActionResult GetHealth()
    {
        return Ok(new { message = "Properties Controller is working", timestamp = DateTime.UtcNow });
    }

    /// <summary>
    /// Obtiene todas las propiedades con filtros opcionales
    /// </summary>
    /// <param name="query">Filtros de búsqueda y paginación</param>
    /// <param name="ct">Token de cancelación</param>
    /// <returns>Lista paginada de propiedades</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResult<PropertyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResult<PropertyDto>>> ListProperties(
        [FromQuery] PropertyFilterQuery query,
        CancellationToken ct)
    {
        try
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
        catch (Exception ex)
        {
                // Log the exception (you would use ILogger here in real code)
            return StatusCode(500, new { error = ex.Message, stackTrace = ex.StackTrace });
        }
    }

    /// <summary>
    /// Obtiene una propiedad específica por su ID
    /// </summary>
    /// <param name="id">ID de la propiedad</param>
    /// <param name="ct">Token de cancelación</param>
    /// <returns>Datos de la propiedad solicitada</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(PropertyDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PropertyDto>> GetProperty(Guid id, CancellationToken ct)
    {
        try
        {
            var dto = await _getHandler.HandleAsync(id.ToString(), ct);
            return dto is null ? NotFound() : Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message, stackTrace = ex.StackTrace });
        }
    }
}
