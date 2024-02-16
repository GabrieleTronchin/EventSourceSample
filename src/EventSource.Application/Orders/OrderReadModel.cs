namespace EventSource.Application.Orders;

public class OrderReadModel
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool Purchased { get; set; }
    public bool PaymentPending { get; set; }

}
