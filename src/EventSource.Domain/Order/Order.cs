namespace EventSource.Domain.Order;

public class OrderEntity
{
    private OrderEntity()
    {
    }

    public static OrderEntity Create(DateTime sessionDate)
    {
        return new OrderEntity();
    }

    public void ReserveOrder()
    {

    }

    public void Purchase()
    {
    }

    public Guid Id { get; private set; }
    public int AuditoriumId { get; private set; }
    public Guid MovieId { get; private set; }
    public DateTime SessionDate { get; private set; }

}