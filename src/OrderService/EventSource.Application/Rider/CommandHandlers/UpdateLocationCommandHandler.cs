using EventSource.Application.Rider.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Rider.CommandHandlers;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, bool>
{
    private readonly ILogger<UpdateLocationCommandHandler> _logger;

    public UpdateLocationCommandHandler(ILogger<UpdateLocationCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        //TODO Append new rider location
        throw new NotImplementedException();
    }
}
