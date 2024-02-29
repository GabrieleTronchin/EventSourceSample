namespace Domain.Abstractions;

public interface IEventRepository
{
    Task StartStream(Guid Id);

    Task Append<T>(Guid Id, T entity);

}
