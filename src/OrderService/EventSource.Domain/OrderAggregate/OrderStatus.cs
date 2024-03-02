namespace EventSource.Domain.OrderAggregate;

public enum OrderStatus
{
    New,
    Accepted,
    OnGoing,
    Completed
}