namespace CleanArchitecture.Application.DTOs.Customer;

/// <summary>
/// DTO for updating an existing customer.
/// </summary>
public record UpdateCustomerDto(
    Guid Id,
    string Name,
    string Email,
    string? Phone
);
