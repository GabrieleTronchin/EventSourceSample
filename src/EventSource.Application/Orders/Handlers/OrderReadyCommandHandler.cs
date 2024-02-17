using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using EventSource.Domain.Primitives;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.Handlers;

public class OrderReadyCommandHandler : IRequestHandler<OrderReadyCommand, OrderReadyCommandComplete>
{
    private readonly ILogger<CreateOrderCommandHandler> _logger;
    private readonly IRepository<OrderEntity> _repository;

    public OrderReadyCommandHandler(ILogger<CreateOrderCommandHandler> logger, IRepository<OrderEntity> orderRepository)
    {
        _logger = logger;
        _repository = orderRepository;
    }

    public Task<OrderReadyCommandComplete> Handle(OrderReadyCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}