using EventSource.Application.Orders.Queries;
using EventSource.Domain.OrderAggregate;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;

public class GetOrderProjectionQueryHandler : IRequestHandler<GetOrderProjectionCommand, OrderStatusReadModel>
{
    private readonly IOrderAggregateQueryableRepository _repository;

    public GetOrderProjectionQueryHandler(IOrderAggregateQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<OrderStatusReadModel> Handle(GetOrderProjectionCommand request, CancellationToken cancellationToken)
    {
        var orderAggregateProjection = await _repository.GetAggregateLiveSingleAsync(request.OrderId, cancellationToken);

        if (orderAggregateProjection == null)
            throw new InvalidOperationException($"Order not found {request.OrderId}");

        return new OrderStatusReadModel()
        {
            Id = request.OrderId,
            CurrentLocation = orderAggregateProjection.CurrentPosition,
            Description = "TODO",
            Status = orderAggregateProjection.Status,
            Traveled = orderAggregateProjection.Traveled,
            RiderId = orderAggregateProjection.RiderId,
        };
    }


}
