namespace Application.Abstractions;

public abstract class IntegrationEvent
{
    protected IntegrationEvent()
    {
        CorrelationId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    public Guid CorrelationId { get; private init; }

    public DateTime CreationDate { get; private init; }

    public override string ToString()
    {
        return $"{nameof(CorrelationId)}:{CorrelationId} ; {nameof(CreationDate)}:{CreationDate}";
    }
}
