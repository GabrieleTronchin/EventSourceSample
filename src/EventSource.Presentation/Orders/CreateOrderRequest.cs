namespace EventSource.Presentation.Orders
{
    public record CreateOrderRequest
    {
        public required string Description { get; init; }
    }
}
