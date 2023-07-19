using Cqrs_Mediatr.Context;
using Cqrs_Mediatr.Models;
using MediatR;

namespace Cqrs_Mediatr.Queries;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery,Order>
{
    private readonly OrderDbContext _context;

    public GetOrderByIdHandler(OrderDbContext context)
    {
        _context = context;
    }

    public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = _context.Orders.FindById(request.Id);
        return Task.FromResult(order);
    }
}