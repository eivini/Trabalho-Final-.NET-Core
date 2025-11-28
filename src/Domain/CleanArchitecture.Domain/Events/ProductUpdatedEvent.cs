namespace CleanArchitecture.Domain.Events;

/// <summary>
/// Domain event raised when a product is updated.
/// </summary>
public class ProductUpdatedEvent : IDomainEvent
{
    public Guid ProductId { get; }
    public DateTime OccurredAt { get; }

    public ProductUpdatedEvent(Guid productId)
    {
        ProductId = productId;
        OccurredAt = DateTime.UtcNow;
    }
}
