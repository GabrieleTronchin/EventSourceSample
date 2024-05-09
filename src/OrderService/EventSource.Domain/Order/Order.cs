namespace EventSource.Domain.Order;

public class OrderEntity
{
    private OrderEntity() { }

    public static OrderEntity Create(string description)
    {
        return new OrderEntity()
        {
            Id = Guid.NewGuid(),
            Description = description,
            LastTimeModified = DateTime.UtcNow
        };
    }

    public void ValidateEntity()
    {
        if (string.IsNullOrWhiteSpace(Description))
            throw new ArgumentNullException(nameof(Description));
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime LastTimeModified { get; set; }
}
