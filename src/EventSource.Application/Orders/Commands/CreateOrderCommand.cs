using MediatR;

namespace EventSource.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<CreateOrderCommandComplete>
{
    public string Description { get; set; }
}

public record CreateOrderCommandComplete
{
    public Guid Id { get; set; }
}
