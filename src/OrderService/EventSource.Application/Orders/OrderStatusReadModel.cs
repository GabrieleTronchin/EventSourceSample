using EventSource.Domain;
using EventSource.Domain.OrderAggregate;

namespace EventSource.Application.Orders;

public class OrderStatusReadModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public OrderStatus Status { get; set; }

    public Guid RiderId { get; set; }

    public Location InitialLocation { get; set; }

    public Location CurrentLocation { get; set; }

    public Location DestinationLocation { get; set; }

    public int Traveled { get; set; }

}
