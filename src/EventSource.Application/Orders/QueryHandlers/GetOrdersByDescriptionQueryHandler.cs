using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;


public class GetOrdersByDescriptionQueryHandler : IRequestHandler<GetOrdersByDescriptionCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public GetOrdersByDescriptionQueryHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
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
