using EventSource.Domain.OrderAggregate;
using Marten;

namespace EventSource.Persistence.OrderAggregate
{
    public class OrderAggregateQueryableRepository(IQuerySession querySession) : IOrderAggregateQueryableRepository
    {

        public async Task<OrderAggregateEntity?> GetAggregateAsyncSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.LoadAsync<OrderAggregateEntity>(id, cancel);
        }

        public async Task<OrderAggregateEntity?> GetAggregateLiveSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.Events.AggregateStreamAsync<OrderAggregateEntity>(id);
        }

    }
}
