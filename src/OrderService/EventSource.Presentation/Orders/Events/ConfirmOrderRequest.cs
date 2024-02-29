namespace EventSource.Presentation.Orders.Events
{
    public record ConfirmOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
