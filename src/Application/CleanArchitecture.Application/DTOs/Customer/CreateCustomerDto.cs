namespace CleanArchitecture.Application.DTOs.Customer;

/// <summary>
/// DTO for creating a new customer.
/// </summary>
public record CreateCustomerDto(
    string Name,
    string Email,
    string? Phone
);
