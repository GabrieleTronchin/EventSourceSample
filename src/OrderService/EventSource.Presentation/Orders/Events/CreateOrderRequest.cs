namespace EventSource.Presentation.Orders.Events
{
    public record CreateOrderRequest
    {
        public required string Description { get; init; }
    }
}
