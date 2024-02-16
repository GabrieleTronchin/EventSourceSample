using MediatR;

namespace EventSource.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<CreateOrderCommandComplete>
{
    public int? Id { get; set; }
}

public record CreateOrderCommandComplete
{
    public int? Id { get; set; }
}
