using MediatR;

namespace EventSource.Application.Orders.Commands;

public class AcceptOrderCommand : IRequest<AcceptOrderCommandComplete>
{
    public Guid Id { get; set; }
}

public record AcceptOrderCommandComplete
{
    public Guid Id { get; set; }
}
