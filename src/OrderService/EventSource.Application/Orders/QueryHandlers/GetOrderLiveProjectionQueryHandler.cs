using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using EventSource.Domain.OrderAggregate;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;

public class GetOrderLiveProjectionQueryHandler
    : IRequestHandler<GetOrderLiveProjectionCommand, OrderStatusReadModel>
{
    private readonly IOrderAggregateQueryableRepository _repository;
    private readonly IOrderQueryableRepository _orderRepository;

    public GetOrderLiveProjectionQueryHandler(
        IOrderAggregateQueryableRepository orderStreamRepository,
        IOrderQueryableRepository orderRepository
    )
    {
        _repository = orderStreamRepository;
        _orderRepository = orderRepository;
    }

    public async Task<OrderStatusReadModel> Handle(
        GetOrderLiveProjectionCommand request,
        CancellationToken cancellationToken
    )
    {
        var orderAggregateProjection = await _repository.GetAggregateLiveSingleAsync(
            request.OrderId,
            cancellationToken
        );

        var order =
            await _orderRepository.GetSingleAsync(request.OrderId, cancellationToken)
            ?? throw new InvalidOperationException($"Order not found {request.OrderId}");

        if (orderAggregateProjection == null)
            throw new InvalidOperationException($"Order not found {request.OrderId}");

        return new OrderStatusReadModel()
        {
            Id = request.OrderId,
            CurrentLocation = orderAggregateProjection.CurrentPosition,
            InitialLocation = orderAggregateProjection.InitialPosition,
            DestinationLocation = orderAggregateProjection.DestinationPosition,
            Description = order.Description,
            Status = orderAggregateProjection.Status,
            Traveled = orderAggregateProjection.Traveled,
            RiderId = orderAggregateProjection.RiderId,
        };
    }
}
