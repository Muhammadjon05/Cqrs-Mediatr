using Cqrs_Mediatr.Context;
using Cqrs_Mediatr.Models;
using MediatR;

namespace Cqrs_Mediatr.Queries;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery,List<Order>>
{
    /// <summary>
    /// IRequestHandler<GetOrdersQuery,List<Order>>
    /// bu yerda GetOrdersQuery classidan va
    /// List<Order> bu return type
    /// </summary>
    private readonly OrderDbContext _orderDbContext;

    public GetOrdersQueryHandler(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public Task<List<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = _orderDbContext.Orders.FindAll();
        return Task.FromResult(orders.ToList());
    }
}