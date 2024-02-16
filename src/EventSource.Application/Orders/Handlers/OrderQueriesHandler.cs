using EventSource.Application.Orders.Queries;
using MediatR;

namespace EventSource.Application.Orders.Handlers;

/// <summary>
/// Just a sample of read model
/// </summary>
public class OrderQueriesHandler : IRequestHandler<GetOrderCommand, IList<OrderReadModel>>
{

    public OrderQueriesHandler()
    {
    }

    public async Task<IList<OrderReadModel>> Handle(GetOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        ////in real word scenario the idea is to compose query using TSQL and Dapper
        //var allAuditoriums = await _repository.GetAllAsync(null, cancellationToken);

        //var readModelAuditorium = new List<OrderReadModel>();

        //foreach (var item in allAuditoriums)
        //{
        //    var seats = item.Seats.Select(s => new SeatReadModel() { Row = s.RowNumber, SeatNumber = s.SeatNumber });
        //    readModelAuditorium.Add(new OrderReadModel() { Id = item.Id, Seats = seats });
        //}

        //return readModelAuditorium;
    }
}
