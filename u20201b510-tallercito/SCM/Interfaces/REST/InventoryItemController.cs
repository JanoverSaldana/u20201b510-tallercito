using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using u20201b510_tallercito.SCM.Domain.Model.Queries;
using u20201b510_tallercito.SCM.Domain.Services;
using u20201b510_tallercito.SCM.Interfaces.REST.Resources;
using u20201b510_tallercito.SCM.Interfaces.REST.Transform;

namespace u20201b510_tallercito.SCM.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available InventoryItem Endpoints")]
public class InventoryItemController(IInventoryItemQueryService inventoryItemQueryService, IInventoryItemCommandService inventoryItemCommandService) : ControllerBase
{
    
    [HttpGet("{id}")]
    [SwaggerOperation("Get InventoryItem by Id")]
    [SwaggerResponse(StatusCodes.Status200OK, "InventoryItem found", typeof(InventoryItemResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "InventoryItem not found")]
    public async Task<IActionResult> GetInventoryItemById(int id)
    {
        var getInventoryItemByIdQuery = new GetInventoryItemByIdQuery(id);
        
        var inventoryItem = await inventoryItemQueryService.Handle(getInventoryItemByIdQuery);
        
        if (inventoryItem == null)
        {
            return NotFound(new { Title = "Not Found", message = "InventoryItem not found" });
        }

        var inventoryItemResource = InventoryItemResourceFromEntityAssembler.ToResourceFromEntity(inventoryItem);

        return Ok(inventoryItemResource);
    }
    
    
    [HttpPost]
    [SwaggerOperation("Create InventoryItem")]
    [SwaggerResponse(StatusCodes.Status201Created, "InventoryItem created", typeof(InventoryItemResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid InventoryItem data")]
    public async Task<IActionResult> CreateInventoryItem([FromBody] CreateInventoryItemResource createInventoryItemResource)
    {
        var createInventoryItemCommand = CreateInventoryItemCommandFromResourceAssembler.ToCommandFromResource(createInventoryItemResource);
        
        var inventoryItem = await inventoryItemCommandService.Handle(createInventoryItemCommand);

        if (inventoryItem == null)
        {
            return BadRequest(new { Title = "Bad Request", message = "Invalid InventoryItem data" });
        }
        
        var inventoryItemResource = InventoryItemResourceFromEntityAssembler.ToResourceFromEntity(inventoryItem);
        
        return CreatedAtAction(nameof(GetInventoryItemById), new { id = inventoryItem.Id }, inventoryItemResource);
    }
    
    
    
}