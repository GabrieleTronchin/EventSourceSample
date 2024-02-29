using Application.Abstractions;

namespace EventSource.Application.Orders.Commands;

public class AcceptOrderCommand : ICommand<AcceptOrderCommandComplete>
{
    public Guid Id { get; set; }
}

public record AcceptOrderCommandComplete
{
    public Guid Id { get; set; }
}
