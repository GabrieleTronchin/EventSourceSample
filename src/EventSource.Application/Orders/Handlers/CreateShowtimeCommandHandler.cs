using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using EventSource.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.Handlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandComplete>
{
    private readonly ILogger<CreateOrderCommandHandler> _logger;
    private readonly IOrderRepository _repository;

    public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger, IOrderRepository orderRepository)
    {
        _logger = logger;
        _repository = orderRepository;
    }

    public async Task<CreateOrderCommandComplete> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        OrderEntity order = OrderEntity.Create(request.Description);

        await _repository.AddAsync(order);

        return new CreateOrderCommandComplete() { Id = order.Id };
    }

}