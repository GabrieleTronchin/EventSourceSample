using MediatR;

namespace EventSource.Application.Orders.Queries
{
    public class GetOrderCommand : IRequest<IList<OrderReadModel>>
    {
    }
}
