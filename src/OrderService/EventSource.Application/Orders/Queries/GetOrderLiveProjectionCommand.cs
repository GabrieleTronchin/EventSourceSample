using Application.Abstractions;

namespace EventSource.Application.Orders.Queries;

public class GetOrderLiveProjectionCommand : IQuery<OrderStatusReadModel>
{
    public Guid OrderId { get; set; }
}
