using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs.Customer;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.UseCases.Customers;

/// <summary>
/// Application service implementation for Customer operations.
/// </summary>
public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);
        return customer is null ? null : MapToDto(customer);
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var customers = await _unitOfWork.Customers.GetAllAsync(cancellationToken);
        return customers.Select(MapToDto);
    }

    public async Task<IEnumerable<CustomerDto>> GetActiveCustomersAsync(CancellationToken cancellationToken = default)
    {
        var customers = await _unitOfWork.Customers.GetActiveCustomersAsync(cancellationToken);
        return customers.Select(MapToDto);
    }

    public async Task<IEnumerable<CustomerDto>> SearchByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var customers = await _unitOfWork.Customers.SearchByNameAsync(name, cancellationToken);
        return customers.Select(MapToDto);
    }

    public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto, CancellationToken cancellationToken = default)
    {
        // Check if email already exists
        var existingCustomer = await _unitOfWork.Customers.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingCustomer is not null)
            throw new ValidationException("Email", "A customer with this email already exists.");

        var customer = Customer.Create(dto.Name, dto.Email, dto.Phone);

        await _unitOfWork.Customers.AddAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(customer);
    }

    public async Task<CustomerDto> UpdateAsync(UpdateCustomerDto dto, CancellationToken cancellationToken = default)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(dto.Id, cancellationToken);
        if (customer is null)
            throw new NotFoundException("Customer", dto.Id);

        // Check if email belongs to another customer
        var existingCustomer = await _unitOfWork.Customers.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingCustomer is not null && existingCustomer.Id != dto.Id)
            throw new ValidationException("Email", "A customer with this email already exists.");

        customer.Update(dto.Name, dto.Email, dto.Phone);

        await _unitOfWork.Customers.UpdateAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return MapToDto(customer);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);
        if (customer is null)
            throw new NotFoundException("Customer", id);

        await _unitOfWork.Customers.DeleteAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task ActivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);
        if (customer is null)
            throw new NotFoundException("Customer", id);

        customer.Activate();
        await _unitOfWork.Customers.UpdateAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeactivateAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id, cancellationToken);
        if (customer is null)
            throw new NotFoundException("Customer", id);

        customer.Deactivate();
        await _unitOfWork.Customers.UpdateAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private static CustomerDto MapToDto(Customer customer)
    {
        return new CustomerDto(
            customer.Id,
            customer.Name,
            customer.Email,
            customer.Phone,
            customer.IsActive,
            customer.CreatedAt,
            customer.UpdatedAt
        );
    }
}
