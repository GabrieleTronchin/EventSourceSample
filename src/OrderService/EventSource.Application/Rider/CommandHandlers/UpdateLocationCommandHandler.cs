using Domain.Abstractions;
using EventSource.Application.Rider.Commands;
using EventSource.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Rider.CommandHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, bool>
{
    private readonly ILogger<UpdateLocationCommandHandler> _logger;
    private readonly IEventRepository _eventRepository;

    public UpdateLocationCommandHandler(
        ILogger<UpdateLocationCommandHandler> logger, 
        IEventRepository eventRepository)
    {
        _logger = logger;
        _eventRepository = eventRepository;
    }

    public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
       await _eventRepository.Append(request.RirderId, new Location(request.Latitute, request.Longitude));
       return true; //TODO use a valid return 
    }
}
