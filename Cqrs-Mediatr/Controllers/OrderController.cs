using Cqrs_Mediatr.Commands;
using Cqrs_Mediatr.Exception;
using Cqrs_Mediatr.Models;
using Cqrs_Mediatr.Notifications;
using Cqrs_Mediatr.Queries;
using LiteDB;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs_Mediatr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var query = new GetOrdersQuery();
        var orders = _mediator.Send<List<Order>>(query);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
    {
        Guid orderId;
        try
        {
            orderId = await _mediator.Send<Guid>(command);
        }
        catch (OrderProductIsNullException e)
        {
            return BadRequest(e.Message);
        }
        await _mediator.Publish(new OrderNotifications() { Id = orderId });
        return Ok(new {Id = orderId});
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderById(Guid orderId )
    {
        var query = new GetOrderByIdQuery() { Id = orderId };
        var order = await _mediator.Send<Order>(query);
        return Ok(order);
    }
} 