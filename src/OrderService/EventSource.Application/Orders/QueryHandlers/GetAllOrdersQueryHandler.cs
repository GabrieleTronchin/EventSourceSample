using System.Linq.Expressions;
using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;

public class GetAllOrdersQueryHandler
    : IRequestHandler<GetAllOrdersCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public GetAllOrdersQueryHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IEnumerable<OrderReadModel>> Handle(
        GetAllOrdersCommand request,
        CancellationToken cancellationToken
    )
    {
        Expression<Func<OrderEntity, bool>>? getExpression = default;
        CancellationToken cancellationToken1 = new();
        if (!string.IsNullOrWhiteSpace(request.SeachOnDescription))
            getExpression = x => x.Description.Contains(request.SeachOnDescription);

        var orders = await _repository.Get(getExpression, cancellationToken1);

        return orders.Select(x => new OrderReadModel() { Id = x.Id, Description = x.Description });
    }
}
