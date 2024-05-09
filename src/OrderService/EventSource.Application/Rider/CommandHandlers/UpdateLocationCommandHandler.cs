using Domain.Abstractions;
using EventSource.Application.Rider.Commands;
using EventSource.Domain;
using EventSource.Domain.OrderAggregate.Events;
using EventSource.Domain.Rider;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Rider.CommandHandlers;

public class UpdateLocationCommandHandler
    : IRequestHandler<UpdateLocationCommand, UpdateLocationCommandComplete>
{
    private readonly ILogger<UpdateLocationCommandHandler> _logger;
    private readonly IEventRepository<RiderEntity> _eventRepository;

    public UpdateLocationCommandHandler(
        ILogger<UpdateLocationCommandHandler> logger,
        IEventRepository<RiderEntity> eventRepository
    )
    {
        _logger = logger;
        _eventRepository = eventRepository;
    }

    public async Task<UpdateLocationCommandComplete> Handle(
        UpdateLocationCommand request,
        CancellationToken cancellationToken
    )
    {
        await _eventRepository.Append(
            request.RirderId,
            new UpdateOrderLocation
            {
                RiderId = request.RirderId,
                CurrentLocation = new Location(request.Latitute, request.Longitude)
            }
        );

        return new UpdateLocationCommandComplete() { RirderId = request.RirderId };
    }
}
