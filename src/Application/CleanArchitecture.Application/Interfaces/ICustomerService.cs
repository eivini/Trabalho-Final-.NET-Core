using CleanArchitecture.Application.DTOs.Customer;

namespace CleanArchitecture.Application.Interfaces;

/// <summary>
/// Application service interface for Customer operations.
/// </summary>
public interface ICustomerService
{
    Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<CustomerDto>> SearchByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<CustomerDto> CreateAsync(CreateCustomerDto dto, CancellationToken cancellationToken = default);
    Task<CustomerDto> UpdateAsync(UpdateCustomerDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task ActivateAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default);
}
