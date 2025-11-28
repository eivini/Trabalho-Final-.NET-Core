using CleanArchitecture.Application.DTOs.Product;

namespace CleanArchitecture.Application.Interfaces;

/// <summary>
/// Application service interface for Product operations.
/// </summary>
public interface IProductService
{
    Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDto>> GetActiveProductsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductDto>> SearchByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken cancellationToken = default);
    Task<ProductDto> UpdateAsync(UpdateProductDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task ActivateAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default);
}
