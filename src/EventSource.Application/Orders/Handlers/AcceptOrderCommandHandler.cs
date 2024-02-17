using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using EventSource.Domain.Primitives;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.Handlers;

public class AcceptOrderCommandHandler : IRequestHandler<AcceptOrderCommand, AcceptOrderCommandComplete>
{
    private readonly ILogger<AcceptOrderCommandHandler> _logger;
    private readonly IRepository<OrderEntity> _repository;

    public AcceptOrderCommandHandler(ILogger<AcceptOrderCommandHandler> logger, IRepository<OrderEntity> orderRepository)
    {
        _logger = logger;
        _repository = orderRepository;
    }

    public Task<AcceptOrderCommandComplete> Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}