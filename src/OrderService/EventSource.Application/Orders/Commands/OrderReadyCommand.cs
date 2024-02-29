using Application.Abstractions;
using MediatR;

namespace EventSource.Application.Orders.Commands;

public class OrderReadyCommand : ICommand<OrderReadyCommandComplete>
{
    public Guid Id { get; set; }
}

public record OrderReadyCommandComplete
{
    public Guid Id { get; set; }
}
