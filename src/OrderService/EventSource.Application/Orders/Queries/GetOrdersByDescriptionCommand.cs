using Application.Abstractions;
using MediatR;

namespace EventSource.Application.Orders.Queries;

public class GetOrdersByDescriptionCommand : IQuery<IEnumerable<OrderReadModel>>
{
    public string Description { get; set; }
}
