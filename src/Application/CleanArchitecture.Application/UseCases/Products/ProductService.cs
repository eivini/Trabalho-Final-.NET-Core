using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs.Product;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.UseCases.Products;

/// <summary>
/// Application service implementation for Product operations.
/// </summary>
public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        return product is null ? null : MapToDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);
        return products.Select(MapToDto);
    }

    public async Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var products = await _unitOfWork.Products.GetByCategoryIdAsync(categoryId, cancellationToken);
        return products.Select(MapToDto);
    }

    public async Task<IEnumerable<ProductDto>> GetActiveProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _unitOfWork.Products.GetActiveProductsAsync(cancellationToken);
        return products.Select(MapToDto);
    }

    public async Task<IEnumerable<ProductDto>> SearchByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var products = await _unitOfWork.Products.SearchByNameAsync(name, cancellationToken);
        return products.Select(MapToDto);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto, CancellationToken cancellationToken = default)
    {
        // Verify category exists
        var category = await _unitOfWork.Categories.GetByIdAsync(dto.CategoryId, cancellationToken);
        if (category is null)
            throw new NotFoundException("Category", dto.CategoryId);

        var product = Product.Create(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.StockQuantity,
            dto.SKU,
            dto.CategoryId
        );

        await _unitOfWork.Products.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(product);
    }

    public async Task<ProductDto> UpdateAsync(UpdateProductDto dto, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(dto.Id, cancellationToken);
        if (product is null)
            throw new NotFoundException("Product", dto.Id);

        product.Update(dto.Name, dto.Description, dto.Price, dto.StockQuantity, dto.SKU);

        await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(product);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        if (product is null)
            throw new NotFoundException("Product", id);

        await _unitOfWork.Products.DeleteAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task ActivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        if (product is null)
            throw new NotFoundException("Product", id);

        product.Activate();
        await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        if (product is null)
            throw new NotFoundException("Product", id);

        product.Deactivate();
        await _unitOfWork.Products.UpdateAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static ProductDto MapToDto(Product product)
    {
        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price.Amount,
            product.Price.Currency,
            product.StockQuantity,
            product.SKU,
            product.IsActive,
            product.CategoryId,
            product.Category?.Name,
            product.CreatedAt,
            product.UpdatedAt
        );
    }
}
