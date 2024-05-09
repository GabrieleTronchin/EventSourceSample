namespace EventSource.Domain.OrderAggregate.Events;

public class OrderAccepted
{
    public Guid RiderId { get; set; }

    public Location InitialLocation { get; set; }
}
