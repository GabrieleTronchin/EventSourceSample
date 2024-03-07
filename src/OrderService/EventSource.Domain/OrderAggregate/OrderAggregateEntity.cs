using EventSource.Domain.OrderAggregate.Events;

namespace EventSource.Domain.OrderAggregate;

public class OrderAggregateEntity
{
    public OrderAggregateEntity()
    {
    }

    public Guid Id { get; set; }

    public OrderStatus Status { get; set; }

    public Guid RiderId { get; set; }

    public Location InitialPosition { get; set; }

    public Location CurrentPosition { get; set; }

    public Location DestinationPosition { get; set; }


    public int Traveled { get; set; }

    public void Apply(OrderAccepted e)
    {
        RiderId = e.RiderId;
        Status = OrderStatus.Accepted;
        InitialPosition = e.InitialLocation;
    }

    public void Apply(OrderCompleted e)
    {
        Status = OrderStatus.Completed;
        DestinationPosition = e.Destination;
    }

    public void Apply(UpdateOrderLocation e)
    {
        Status = OrderStatus.OnGoing;
        CurrentPosition = e.CurrentLocation;
        Traveled += e.CurrentLocation.Longitude;
    }


}
