using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using Swashbuckle.AspNetCore.Annotations;
using u20201b510_tallercito.SCM.Interfaces.ACL;
using u20201b510_tallercito.SD.Application.OutboundServices;
using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Commands;
using u20201b510_tallercito.SD.Domain.Model.Queries;
using u20201b510_tallercito.SD.Domain.Repositories;
using u20201b510_tallercito.SD.Domain.Services;
using u20201b510_tallercito.SD.Interfaces.REST.Resources;
using u20201b510_tallercito.SD.Interfaces.REST.Transform;

namespace u20201b510_tallercito.SD.Interfaces.REST;




[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Order Item Endpoints")]
public class OrderItemController(IOrderItemQueryService orderItemQueryService, IOrderItemCommandService orderItemCommandService, ExternalIInventoryItemService inventoryItemService) : ControllerBase
{
    // /api/v1/orders/{orderId}
    [HttpGet("{orderId:int}")]
    [SwaggerOperation(
        Summary = "Get an order item by id",
        Description = "Get an order item by id",
        OperationId = "GetOrderItemById"
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "The order item was successfully retrieved", typeof(OrderItemResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The order item was not found")]
    public async Task<IActionResult> GetOrderItemById(int orderId)
    {
        var getOrderItemByIdQuery = new GetOrderItemByIdQuery(orderId);
        var orderItem = await orderItemQueryService.Handle(getOrderItemByIdQuery);
        if (orderItem is null) return NotFound();
        var orderItemResource = OrderItemResourceFromEntityAssembler.ToResourceFromEntity(orderItem);
        return Ok(orderItemResource);
    }
    
    // /api/v1/orders/{orderId}/items [POST]
    [HttpPost ("{orderId:int}/items")]
    [SwaggerOperation(
        Summary = "Create an order item",
        Description = "Create an order item",
        OperationId = "CreateOrderItem"
    )]
    [SwaggerResponse(StatusCodes.Status201Created, "The order item was successfully created", typeof(OrderItemResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The order item was not created")]
    public async Task<IActionResult> CreateOrderItem([FromBody] CreateOrderItemResource resource, int orderId)
    {
        bool exists = await inventoryItemService.existsInventoryItemByProductSku(resource.ProductSku);

        if (exists == false) return BadRequest(new { Title = "Bad Request", message = "The product sku does not exist" });
        
        var createOrderItemCommand = CreateOrderItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var orderItem = await orderItemCommandService.Handle(createOrderItemCommand, orderId);
        
        if(orderItem is null)  return BadRequest(new { Title = "Bad Request", message = "The order item was not created" });
        
        var orderItemResource = OrderItemResourceFromEntityAssembler.ToResourceFromEntity(orderItem);
        
        return CreatedAtAction(nameof(GetOrderItemById), new { orderId = orderItem.Id }, orderItemResource);
    }
  
    
}