using EventSource.Domain.OrderAggregate;
using EventSource.Domain.OrderAggregate.Events;
using Marten.Events.Aggregation;

namespace EventSource.Persistence.OrderAggregate;

public class OrderAggregateProjection : SingleStreamProjection<OrderAggregateEntity>
{
    public OrderAggregateProjection()
    {
        ProjectEvent<OrderAccepted>((order, e) =>
        {
            order.RiderId = e.RiderId;
            order.Status = OrderStatus.Accepted;
            order.InitialPosition = e.InitialLocation;
        });

        ProjectEvent<OrderCompleted>((order, e) =>
        {
            order.Status = OrderStatus.Completed;
            order.DestinationPosition = e.Destination;
        });

        ProjectEvent<UpdateOrderLocation>((order, e) =>
        {
            order.Status = OrderStatus.OnGoing;
            order.Traveled += e.CurrentLocation.Longitude;
        });

    }
}
