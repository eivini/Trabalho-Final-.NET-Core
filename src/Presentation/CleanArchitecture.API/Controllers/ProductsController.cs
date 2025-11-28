using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs.Product;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

/// <summary>
/// API Controller for Product operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Get all products.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);
        return Ok(products);
    }

    /// <summary>
    /// Get a product by ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productService.GetByIdAsync(id, cancellationToken);
        if (product is null)
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Get products by category ID.
    /// </summary>
    [HttpGet("category/{categoryId:guid}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        var products = await _productService.GetByCategoryIdAsync(categoryId, cancellationToken);
        return Ok(products);
    }

    /// <summary>
    /// Get active products.
    /// </summary>
    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetActive(CancellationToken cancellationToken)
    {
        var products = await _productService.GetActiveProductsAsync(cancellationToken);
        return Ok(products);
    }

    /// <summary>
    /// Search products by name.
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Search([FromQuery] string name, CancellationToken cancellationToken)
    {
        var products = await _productService.SearchByNameAsync(name, cancellationToken);
        return Ok(products);
    }

    /// <summary>
    /// Create a new product.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ProductDto>> Update(Guid id, [FromBody] UpdateProductDto dto, CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var product = await _productService.UpdateAsync(dto, cancellationToken);
            return Ok(product);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a product.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _productService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Activate a product.
    /// </summary>
    [HttpPost("{id:guid}/activate")]
    public async Task<ActionResult> Activate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _productService.ActivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deactivate a product.
    /// </summary>
    [HttpPost("{id:guid}/deactivate")]
    public async Task<ActionResult> Deactivate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _productService.DeactivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
