namespace EventSource.Presentation.Orders.Events
{
    public record OrderReadyRequest
    {
        public required Guid OrderId { get; init; }
    }
}
