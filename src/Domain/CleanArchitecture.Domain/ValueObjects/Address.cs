using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.ValueObjects;

/// <summary>
/// Value Object representing an address.
/// </summary>
public class Address : ValueObject
{
    public string Street { get; }
    public string Number { get; }
    public string? Complement { get; }
    public string Neighborhood { get; }
    public string City { get; }
    public string State { get; }
    public string ZipCode { get; }
    public string Country { get; }

    private Address(string street, string number, string? complement, 
        string neighborhood, string city, string state, string zipCode, string country)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
    }

    public static Address Create(string street, string number, string? complement,
        string neighborhood, string city, string state, string zipCode, string country = "Brasil")
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required", nameof(street));

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required", nameof(city));

        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State is required", nameof(state));

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("ZipCode is required", nameof(zipCode));

        return new Address(street, number, complement, neighborhood, city, state, zipCode, country);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Number;
        yield return Complement ?? string.Empty;
        yield return Neighborhood;
        yield return City;
        yield return State;
        yield return ZipCode;
        yield return Country;
    }

    public override string ToString() => 
        $"{Street}, {Number}{(string.IsNullOrEmpty(Complement) ? "" : $" - {Complement}")}, {Neighborhood}, {City}/{State} - {ZipCode}, {Country}";
}
