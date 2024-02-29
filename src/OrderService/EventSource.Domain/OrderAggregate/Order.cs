namespace EventSource.Domain.Order;

public class OrderAggregate
{
    public OrderAggregate()
    {
    }


    public OrderStatus Status { get; set; }

    public Guid RiderId { get; set; }

    public Location CurrentLocation { get; set; }


}
