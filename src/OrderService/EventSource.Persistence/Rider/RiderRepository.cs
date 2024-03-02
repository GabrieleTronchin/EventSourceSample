using Domain.Abstractions;
using EventSource.Domain.Rider;
using Marten;


namespace EventSource.Persistence.Rider;

public class RiderRepository(IDocumentStore store) : IRepository<RiderEntity>, IEventRepository
{

    public async Task AddAsync(RiderEntity entity)
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
