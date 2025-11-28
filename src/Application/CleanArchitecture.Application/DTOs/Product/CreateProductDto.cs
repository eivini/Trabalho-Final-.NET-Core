namespace CleanArchitecture.Application.DTOs.Product;

/// <summary>
/// DTO for creating a new product.
/// </summary>
public record CreateProductDto(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU,
    Guid CategoryId
);
