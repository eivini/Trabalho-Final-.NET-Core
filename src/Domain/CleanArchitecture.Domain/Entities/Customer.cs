using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Customer entity - Aggregate Root following DDD principles.
/// </summary>
public class Customer : AggregateRoot
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public Address? Address { get; private set; }
    public bool IsActive { get; private set; }

    private Customer() : base()
    {
        Name = string.Empty;
        Email = string.Empty;
    }

    private Customer(string name, string email, string? phone) : base()
    {
        Name = name;
        Email = email;
        Phone = phone;
        IsActive = true;
    }

    public static Customer Create(string name, string email, string? phone = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));

        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format", nameof(email));

        return new Customer(name, email, phone);
    }

    public void Update(string name, string email, string? phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));

        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format", nameof(email));

        Name = name;
        Email = email;
        Phone = phone;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAddress(Address address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
