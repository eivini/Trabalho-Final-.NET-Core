using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Events;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Product entity - Aggregate Root following DDD principles.
/// </summary>
public class Product : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Money Price { get; private set; }
    public int StockQuantity { get; private set; }
    public string SKU { get; private set; }
    public bool IsActive { get; private set; }
    
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }

    private Product() : base()
    {
        Name = string.Empty;
        Description = string.Empty;
        SKU = string.Empty;
        Price = Money.Create(0);
    }

    private Product(string name, string description, Money price, int stockQuantity, string sku, Guid categoryId) : base()
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        SKU = sku;
        CategoryId = categoryId;
        IsActive = true;

        AddDomainEvent(new ProductCreatedEvent(Id, name));
    }

    public static Product Create(string name, string description, decimal price, 
        int stockQuantity, string sku, Guid categoryId)
    {
        ValidateProductData(name, description, price, stockQuantity, sku);

        return new Product(name, description, Money.Create(price), stockQuantity, sku, categoryId);
    }

    public void Update(string name, string description, decimal price, int stockQuantity, string sku)
    {
        ValidateProductData(name, description, price, stockQuantity, sku);

        Name = name;
        Description = description;
        Price = Money.Create(price);
        StockQuantity = stockQuantity;
        SKU = sku;
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductUpdatedEvent(Id));
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new ArgumentException("Price cannot be negative", nameof(newPrice));

        Price = Money.Create(newPrice);
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductUpdatedEvent(Id));
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive", nameof(quantity));

        StockQuantity += quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive", nameof(quantity));

        if (StockQuantity < quantity)
            throw new InvalidOperationException("Insufficient stock quantity");

        StockQuantity -= quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeCategory(Guid newCategoryId)
    {
        CategoryId = newCategoryId;
        UpdatedAt = DateTime.UtcNow;
    }

    private static void ValidateProductData(string name, string description, decimal price, 
        int stockQuantity, string sku)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Product description is required", nameof(description));

        if (price < 0)
            throw new ArgumentException("Price cannot be negative", nameof(price));

        if (stockQuantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative", nameof(stockQuantity));

        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required", nameof(sku));
    }
}
