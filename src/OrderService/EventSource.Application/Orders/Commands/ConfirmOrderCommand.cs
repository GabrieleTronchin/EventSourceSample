using MediatR;

namespace EventSource.Application.Orders.Commands;

public class ConfirmOrderCommand : IRequest<ConfirmOrderCommandComplete>
{
    public Guid Id { get; set; }
}

public record ConfirmOrderCommandComplete
{
    public Guid Id { get; set; }
}
