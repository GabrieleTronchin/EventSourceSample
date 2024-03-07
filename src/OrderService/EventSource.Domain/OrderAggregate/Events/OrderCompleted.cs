namespace EventSource.Domain.OrderAggregate.Events;

public class OrderCompleted
{
    public Guid RiderId { get; set; }

    public Location Destination { get; set; }
}
