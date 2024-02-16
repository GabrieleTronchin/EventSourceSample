using MediatR;

namespace EventSource.Application.Orders.Queries
{
    public class GetAllOrdersCommand : IRequest<IEnumerable<OrderReadModel>>
    {
    }
}
