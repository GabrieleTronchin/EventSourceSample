using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using EventSource.Domain.Primitives;
using EventSource.Persistence;
using MediatR;

namespace EventSource.Application.Orders.Handlers;

/// <summary>
/// Just a sample of read model
/// </summary>
public class OrderQueriesHandler : IRequestHandler<GetOrderCommand, IList<OrderReadModel>>
{
    private readonly IOrderRepository _repository;

    public OrderQueriesHandler(IOrderRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IList<OrderReadModel>> Handle(GetOrderCommand request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAsync(null, cancellationToken);


        //TODO better implemenetation
        var readModelOder = new List<OrderReadModel>();

        foreach (var item in orders)
        {
           readModelOder.Add(new OrderReadModel() { Id = item.Id , Description = item.Description});
        }

        return readModelOder;
    }
}
