using Domain.Abstractions;
using EventSource.Application.Rider.Commands;
using EventSource.Domain;
using EventSource.Domain.Order;
using EventSource.Domain.Rider;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Rider.CommandHandlers;

public class AcceptOrderCommandHandler : IRequestHandler<AcceptOrderCommand, AcceptOrderCommandComplete>
{
    private readonly ILogger<AcceptOrderCommandHandler> _logger;
    private readonly IRepository<RiderEntity> _riderRepository;
    private readonly IEventRepository _eventRepository;

    public AcceptOrderCommandHandler(ILogger<AcceptOrderCommandHandler> logger,
                                    IRepository<RiderEntity> riderRepository)
    {
        _logger = logger;
        _riderRepository = riderRepository;
    }

    public async Task<AcceptOrderCommandComplete> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
    {
        var rider = RiderEntity.Create(request.Id, new Location(0, 0));


        await _riderRepository.AddAsync(rider);


        await _eventRepository.Append(request.Id, new { Status = OrderStatus.Accepted });
        return new AcceptOrderCommandComplete() { Id = request.Id };
    }
}