using Application.Abstractions;

namespace EventSource.Application.Orders.Queries;

public class GetOrderSnapshotProjectionCommand : IQuery<OrderStatusReadModel>
{
    public Guid OrderId { get; set; }
}
