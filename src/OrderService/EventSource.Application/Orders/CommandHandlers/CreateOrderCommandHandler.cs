using Domain.Abstractions;
using EventSource.Application.Orders.Commands;
using EventSource.Domain.Order;
using EventSource.Domain.Rider;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventSource.Application.Orders.CommandHandlers;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandComplete>
{
    private readonly ILogger<CreateOrderCommandHandler> _logger;
    private readonly IRepository<OrderEntity> _repository;
    private readonly IEventRepository<RiderEntity> _eventRepository;

    public CreateOrderCommandHandler(ILogger<CreateOrderCommandHandler> logger,
                                    IRepository<OrderEntity> repository,
                                    IEventRepository<RiderEntity> eventRepository)
    {
        _logger = logger;
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<CreateOrderCommandComplete> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        OrderEntity order = OrderEntity.Create(request.Description);

        await _repository.AddAsync(order);

        await _eventRepository.StartStream(order.Id);

        return new CreateOrderCommandComplete() { Id = order.Id };
    }

}