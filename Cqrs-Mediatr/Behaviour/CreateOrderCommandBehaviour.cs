using Cqrs_Mediatr.Commands;
using Cqrs_Mediatr.Exception;
using MediatR;

namespace Cqrs_Mediatr.Behaviour;

public class CreateOrderCommandBehaviour : IPipelineBehavior<CreateOrderCommand,Guid>
{
    private readonly ILogger _logger;

    public CreateOrderCommandBehaviour(ILogger<CreateOrderCommandBehaviour> logger)
    {
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateOrderCommand request,
        RequestHandlerDelegate<Guid> next,
        CancellationToken cancellationToken)
    {
        if (request.ProductPrices == null || request.ProductPrices.Count == 0)
        {
            throw new OrderProductIsNullException("Order can not be null or empty");
        }

        return await next();
    }
}