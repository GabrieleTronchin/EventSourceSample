namespace EventSource.Presentation.Orders
{
    public record AcceptOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
