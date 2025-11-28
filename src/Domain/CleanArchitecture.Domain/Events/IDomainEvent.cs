namespace CleanArchitecture.Domain.Events;

/// <summary>
/// Marker interface for domain events following DDD principles.
/// </summary>
public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}
