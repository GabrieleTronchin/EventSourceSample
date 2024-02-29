using MediatR;

namespace EventSource.Application.Orders.Queries
{
    public class GetOrdersByDescriptionCommand : IRequest<IEnumerable<OrderReadModel>>
    {
        public string Description { get; set; }
    }
}
