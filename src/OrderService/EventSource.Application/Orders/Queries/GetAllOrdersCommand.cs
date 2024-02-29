using Application.Abstractions;

namespace EventSource.Application.Orders.Queries;

public class GetAllOrdersCommand : IQuery<IEnumerable<OrderReadModel>>
{
    public string? SeachOnDescription { get; set; }
}
