using Domain.Abstractions;
using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.CommandHandlers;

public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, ConfirmOrderCommandComplete>
{
    private readonly ILogger<ConfirmOrderCommandHandler> _logger;
    private readonly IRepository<OrderEntity> _repository;

    public ConfirmOrderCommandHandler(ILogger<ConfirmOrderCommandHandler> logger, IRepository<OrderEntity> orderRepository)
    {
        _logger = logger;
        _repository = orderRepository;
    }

    public Task<ConfirmOrderCommandComplete> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}