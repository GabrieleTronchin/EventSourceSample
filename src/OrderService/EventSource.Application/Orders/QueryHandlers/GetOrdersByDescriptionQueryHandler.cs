using EventSource.Application.Orders.Queries;
using EventSource.Application.Orders.Queries.Validators;
using EventSource.Domain.Order;
using FluentValidation;
using MediatR;

namespace EventSource.Application.Orders.QueryHandlers;


internal sealed class GetOrdersByDescriptionQueryHandler : IRequestHandler<GetOrdersByDescriptionCommand, IEnumerable<OrderReadModel>>
{
    private readonly IOrderQueryableRepository _repository;

    public GetOrdersByDescriptionQueryHandler(IOrderQueryableRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public async Task<IEnumerable<OrderReadModel>> Handle(GetOrdersByDescriptionCommand request, CancellationToken cancellationToken)
    {

        var order = await _repository.Get(x => x.Description == request.Description, cancellationToken);

        return order.Select(x => new OrderReadModel() { Id = x.Id, Description = x.Description });

    }

}
