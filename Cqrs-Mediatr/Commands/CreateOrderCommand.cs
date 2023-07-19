using MediatR;

namespace Cqrs_Mediatr.Commands;
                                                            
public class CreateOrderCommand : IRequest<Guid>
{
    //IRequest<Guid> = bu Guid return type
    public List<decimal>? ProductPrices { get; set; }
    //bu parametrlar
}