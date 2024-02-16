namespace EventSource.Domain.Order;

public class OrderEntity
{
    private OrderEntity()
    {
    }

    public static OrderEntity Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentNullException("description");

        return new OrderEntity() { Id=Guid.NewGuid(), Description=description };
    }

    public void RequestPayment()
    {
        PaymentPending = true;
    }

    public void Purchase()
    {
        Purchased = true;
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public bool Purchased { get; private set; }
    public bool PaymentPending { get; private set; }
}