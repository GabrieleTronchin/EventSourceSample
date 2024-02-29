using Domain.Abstractions;
using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.CommandHandlers;

public class AcceptOrderCommandHandler : IRequestHandler<AcceptOrderCommand, AcceptOrderCommandComplete>
{
    private readonly ILogger<AcceptOrderCommandHandler> _logger;
    private readonly IEventRepository _eventRepository;

    public AcceptOrderCommandHandler(ILogger<AcceptOrderCommandHandler> logger, IEventRepository eventRepository)
    {
        _logger = logger;
        _eventRepository = eventRepository;
    }

    public async Task<AcceptOrderCommandComplete> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
    {
        await _eventRepository.Append(request.Id, new { Status = OrderStatus.Accepted });
        return new AcceptOrderCommandComplete() { Id = request.Id };
    }
}