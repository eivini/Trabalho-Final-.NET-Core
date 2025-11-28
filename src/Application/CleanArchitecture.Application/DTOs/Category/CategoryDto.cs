namespace CleanArchitecture.Application.DTOs.Category;

/// <summary>
/// DTO for category responses.
/// </summary>
public record CategoryDto(
    Guid Id,
    string Name,
    string? Description,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
