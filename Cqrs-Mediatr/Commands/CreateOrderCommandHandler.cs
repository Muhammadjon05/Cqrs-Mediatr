using Cqrs_Mediatr.Context;
using Cqrs_Mediatr.Models;
using MediatR;

namespace Cqrs_Mediatr.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Guid>
{
    private readonly OrderDbContext _orderDbContext;

    public CreateOrderCommandHandler(OrderDbContext orderDbContext)
    {
        _orderDbContext = orderDbContext;
    }

    public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order()
        {
            Id = new Guid(),
            TotalPrice = request.ProductPrices!.Sum()
        };
        _orderDbContext.Orders.Insert(order);
        return Task.FromResult(order.Id);
    }
    
}