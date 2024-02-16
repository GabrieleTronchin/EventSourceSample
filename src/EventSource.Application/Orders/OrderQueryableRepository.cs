using Marten;
using System.Linq.Expressions;

namespace EventSource.Application.Orders
{
    public class OrderQueryableRepository(IQuerySession querySession) : IOrderQueryableRepository
    {
        public IEnumerable<OrderReadModel> Get()
        {
            return querySession.Query<OrderReadModel>();
        }

        public IEnumerable<OrderReadModel> Get(Expression<Func<OrderReadModel, bool>> filter, CancellationToken cancel)
        {
            return querySession.Query<OrderReadModel>().Where(filter);
        }

        public async Task<OrderReadModel?> GetSingleAsync(Guid id, CancellationToken cancel)
        {
            return await querySession.Query<OrderReadModel>().Where(x => x.Id == id).FirstOrDefaultAsync(cancel);
        }

    }
}
