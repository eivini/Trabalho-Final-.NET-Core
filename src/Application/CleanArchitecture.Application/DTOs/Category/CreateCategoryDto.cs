namespace CleanArchitecture.Application.DTOs.Category;

/// <summary>
/// DTO for creating a new category.
/// </summary>
public record CreateCategoryDto(
    string Name,
    string? Description
);
