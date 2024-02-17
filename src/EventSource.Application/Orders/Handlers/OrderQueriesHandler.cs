using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using MediatR;

namespace EventSource.Application.Orders.Handlers;

/// <summary>
/// Just a sample of read model
/// </summary>
public class OrderQueriesHandler : IRequestHandler<GetAllOrdersCommand, IEnumerable<OrderReadModel>>,
                                   IRequestHandler<GetOrdersByDescriptionCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public OrderQueriesHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IEnumerable<OrderReadModel>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
    {
        return _repository.Get();
    }


    public async Task<IEnumerable<OrderReadModel>> Handle(GetOrdersByDescriptionCommand request, CancellationToken cancellationToken)
    {

        if (string.IsNullOrWhiteSpace(request.Description))
            throw new NotImplementedException();


        return _repository.Get(x => x.Description == request.Description, cancellationToken);

    }

}
