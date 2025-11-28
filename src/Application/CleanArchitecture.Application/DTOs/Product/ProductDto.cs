namespace CleanArchitecture.Application.DTOs.Product;

/// <summary>
/// DTO for product responses.
/// </summary>
public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    string Currency,
    int StockQuantity,
    string SKU,
    bool IsActive,
    Guid CategoryId,
    string? CategoryName,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
