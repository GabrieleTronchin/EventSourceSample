namespace EventSource.Presentation.Orders
{
    public record ConfirmOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
