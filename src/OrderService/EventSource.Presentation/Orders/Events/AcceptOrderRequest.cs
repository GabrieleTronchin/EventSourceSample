namespace EventSource.Presentation.Orders.Events
{
    public record AcceptOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
