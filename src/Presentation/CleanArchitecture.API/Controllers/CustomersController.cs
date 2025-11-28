using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs.Customer;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

/// <summary>
/// API Controller for Customer operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Get all customers.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAllAsync(cancellationToken);
        return Ok(customers);
    }

    /// <summary>
    /// Get a customer by ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(id, cancellationToken);
        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    /// <summary>
    /// Get active customers.
    /// </summary>
    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetActive(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetActiveCustomersAsync(cancellationToken);
        return Ok(customers);
    }

    /// <summary>
    /// Search customers by name.
    /// </summary>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Search([FromQuery] string name, CancellationToken cancellationToken)
    {
        var customers = await _customerService.SearchByNameAsync(name, cancellationToken);
        return Ok(customers);
    }

    /// <summary>
    /// Create a new customer.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create([FromBody] CreateCustomerDto dto, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _customerService.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing customer.
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> Update(Guid id, [FromBody] UpdateCustomerDto dto, CancellationToken cancellationToken)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            var customer = await _customerService.UpdateAsync(dto, cancellationToken);
            return Ok(customer);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Errors);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a customer.
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _customerService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Activate a customer.
    /// </summary>
    [HttpPost("{id:guid}/activate")]
    public async Task<ActionResult> Activate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _customerService.ActivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deactivate a customer.
    /// </summary>
    [HttpPost("{id:guid}/deactivate")]
    public async Task<ActionResult> Deactivate(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _customerService.DeactivateAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
