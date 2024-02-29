namespace EventSource.Presentation.Rider.Events
{
    public record AcceptOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
