using Domain.Abstractions;
using EventSource.Domain.Order;
using Marten;


namespace EventSource.Persistence.Order;

public class OrderRepository(IDocumentStore store) : IRepository<OrderEntity>
{

    //TODO Implement in a correct way
    // https://www.youtube.com/watch?v=yWpuUHXLhYg&ab_channel=CodeOpinion

    public async Task AddAsync(OrderEntity entity)
    {
        using var session = await store.LightweightSerializableSessionAsync();
        session.Store(entity);
        await session.SaveChangesAsync();
    }

    public async Task Append<T>(Guid Id, T entity)
    {
        using var session = await store.LightweightSerializableSessionAsync();
        session.Events.Append(Id, entity);
        await session.SaveChangesAsync();
    }

    public async Task StartStream(Guid Id)
    {
        using var session = await store.LightweightSerializableSessionAsync();
        session.Events.StartStream(Id);
        await session.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

}
