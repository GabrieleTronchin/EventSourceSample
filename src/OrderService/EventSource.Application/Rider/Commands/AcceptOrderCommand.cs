using Application.Abstractions;

namespace EventSource.Application.Rider.Commands;

public class AcceptOrderCommand : ICommand<AcceptOrderCommandComplete>
{
    public Guid Id { get; set; }

    public Guid RiderId { get; set; }
}

public record AcceptOrderCommandComplete
{
    public Guid Id { get; set; }
}
