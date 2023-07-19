using Cqrs_Mediatr.Models;
using MediatR;

namespace Cqrs_Mediatr.Queries;

public class GetOrderByIdQuery : IRequest<Order>
{
    public Guid Id { get; set; }
}