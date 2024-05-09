namespace EventSource.Domain.OrderAggregate.Events;

public class UpdateOrderLocation
{
    public Guid RiderId { get; set; }

    public Location CurrentLocation { get; set; }
}
