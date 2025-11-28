namespace CleanArchitecture.Application.DTOs.Customer;

/// <summary>
/// DTO for customer responses.
/// </summary>
public record CustomerDto(
    Guid Id,
    string Name,
    string Email,
    string? Phone,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
