using Application.Abstractions;

namespace EventSource.Application.Orders.Queries;

public class GetOrdersByDescriptionCommand : IQuery<IEnumerable<OrderReadModel>>
{
    public string Description { get; set; }
}
