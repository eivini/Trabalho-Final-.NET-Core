namespace CleanArchitecture.Application.DTOs.Category;

/// <summary>
/// DTO for updating an existing category.
/// </summary>
public record UpdateCategoryDto(
    Guid Id,
    string Name,
    string? Description
);
