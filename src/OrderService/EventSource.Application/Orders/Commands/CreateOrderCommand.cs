using Application.Abstractions;
using MediatR;

namespace EventSource.Application.Orders.Commands;

public class CreateOrderCommand : ICommand<CreateOrderCommandComplete>
{
    public string Description { get; set; }
}

public record CreateOrderCommandComplete
{
    public Guid Id { get; set; }
}
