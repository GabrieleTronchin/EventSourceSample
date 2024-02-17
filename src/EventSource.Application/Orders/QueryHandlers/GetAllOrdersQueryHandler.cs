using EventSource.Application.Orders.Queries;
using EventSource.Domain.Order;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public GetAllOrdersQueryHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IEnumerable<OrderReadModel>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
    {
        return _repository.Get().Select(x => new OrderReadModel() { Id = x.Id, Description = x.Description });
    }


}
