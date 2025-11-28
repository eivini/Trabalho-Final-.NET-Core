namespace CleanArchitecture.Application.DTOs.Product;

/// <summary>
/// DTO for updating an existing product.
/// </summary>
public record UpdateProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string SKU
);
