using EventSource.Domain.OrderAggregate;
using EventSource.Domain.Rider;
using Marten.Events.Aggregation;

namespace EventSource.Persistence.OrderAggregate
{
    internal class OrderAggregateProjection : SingleStreamProjection<OrderAggregateEntity>
    {
        public OrderAggregateProjection()
        {
            ProjectEvent<RiderEntity>((order, e) => order.CurrentLocation = e.Location);
            ProjectEvent<RiderEntity>((order, e) => order.Traveled += e.Location.Longitude); // just a sample of an aggregate that you can calculate
            ProjectEvent<RiderEntity>((order, e) => order.Status = OrderStatus.OnGoing); // TODO evalutate dinamically

        }
    }
}
