using MediatR;

namespace EventSource.Application.Orders.Commands;

public class OrderReadyCommand : IRequest<OrderReadyCommandComplete>
{
    public Guid Id { get; set; }
}

public record OrderReadyCommandComplete
{
    public Guid Id { get; set; }
}
