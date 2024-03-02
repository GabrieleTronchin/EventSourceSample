using Application.Abstractions;

namespace EventSource.Application.Orders.Queries;

public class GetOrderProjectionCommand : IQuery<OrderStatusReadModel>
{
    public Guid OrderId { get; set; }
}
