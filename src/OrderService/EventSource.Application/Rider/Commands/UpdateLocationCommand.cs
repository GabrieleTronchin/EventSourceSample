using Application.Abstractions;

namespace EventSource.Application.Rider.Commands;

public class UpdateLocationCommand : ICommand<UpdateLocationCommandComplete>
{
    public required Guid RirderId { get; init; }
    public required int Latitute { get; init; }
    public required int Longitude { get; init; }
}

public record UpdateLocationCommandComplete
{
    public Guid RirderId { get; set; }
}
