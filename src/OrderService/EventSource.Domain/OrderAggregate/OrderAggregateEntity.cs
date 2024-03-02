using EventSource.Domain.Rider;
using System.Diagnostics;

namespace EventSource.Domain.OrderAggregate;

public class OrderAggregateEntity
{
    public OrderAggregateEntity()
    {
    }


    public OrderStatus Status { get; set; }

    public Guid RiderId { get; set; }

    public Location CurrentLocation { get; set; }

    public int Traveled { get; set; }

    internal void Apply(RiderEntity e) => CurrentLocation = e.Location;



}
