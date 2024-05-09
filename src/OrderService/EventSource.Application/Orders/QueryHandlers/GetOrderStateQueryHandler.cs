using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;

public class GetOrderStateQueryHandler
    : IRequestHandler<GetAllOrdersCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public GetOrderStateQueryHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IEnumerable<OrderReadModel>> Handle(
        GetAllOrdersCommand request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
