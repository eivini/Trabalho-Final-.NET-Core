using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

/// <summary>
/// Entity Framework configuration for Customer entity.
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Phone)
            .HasMaxLength(20);

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.OwnsOne<Address>(c => c.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Street).HasMaxLength(200);
            addressBuilder.Property(a => a.Number).HasMaxLength(20);
            addressBuilder.Property(a => a.Complement).HasMaxLength(100);
            addressBuilder.Property(a => a.Neighborhood).HasMaxLength(100);
            addressBuilder.Property(a => a.City).HasMaxLength(100);
            addressBuilder.Property(a => a.State).HasMaxLength(50);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(20);
            addressBuilder.Property(a => a.Country).HasMaxLength(100);
        });
    }
}
