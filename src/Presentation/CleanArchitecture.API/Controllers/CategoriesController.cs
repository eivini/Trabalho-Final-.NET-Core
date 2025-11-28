using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs.Category;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

/// <summary>
/// API Controller for Category operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Get all categories.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetAllAsync(cancellationToken);
        return Ok(categories);
    }

    /// <summary>
    /// Get a category by ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(id, cancellationToken);
        if (category is null)
            return NotFound();

        return Ok(category);
    }

    /// <summary>
    /// Get active categories.
    /// </summary>
    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetActive(CancellationToken cancellationToken)
    {
        var categories = await _categoryService.GetActiveCategoriesAsync(cancellationToken);
        return Ok(categories);
    }

    /// <summary>
    /// Create a new category.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing category.
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CategoryDto>> Update(Guid id, [FromBody] UpdateCategoryDto dto, CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var category = await _categoryService.UpdateAsync(dto, cancellationToken);
            return Ok(category);
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
    /// Delete a category.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _categoryService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Activate a category.
    /// </summary>
    [HttpPost("{id:guid}/activate")]
    public async Task<ActionResult> Activate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _categoryService.ActivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deactivate a category.
    /// </summary>
    [HttpPost("{id:guid}/deactivate")]
    public async Task<ActionResult> Deactivate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _categoryService.DeactivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
