namespace CleanArchitecture.Domain.Events;

/// <summary>
/// Domain event raised when a product is created.
/// </summary>
public class ProductCreatedEvent : IDomainEvent
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public DateTime OccurredAt { get; }

    public ProductCreatedEvent(Guid productId, string productName)
    {
        ProductId = productId;
        ProductName = productName;
        OccurredAt = DateTime.UtcNow;
    }
}
