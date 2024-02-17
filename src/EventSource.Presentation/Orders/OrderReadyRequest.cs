namespace EventSource.Presentation.Orders
{
    public record OrderReadyRequest
    {
        public required Guid OrderId { get; init; }
    }
}
