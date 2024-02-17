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
        return _repository.Get().Select(x => new OrderReadModel() { Id=x.Id, Description=x.Description });
    }


    public async Task<IEnumerable<OrderReadModel>> Handle(GetOrdersByDescriptionCommand request, CancellationToken cancellationToken)
    {

        if (string.IsNullOrWhiteSpace(request.Description))
            throw new ArgumentNullException(nameof(request.Description));


        return _repository
                        .Get(x => x.Description == request.Description, cancellationToken)
                        .Select(x => new OrderReadModel() { Id = x.Id, Description = x.Description });

    }

}
