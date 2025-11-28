using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrabalhoFinal.Domain.Entities;

namespace TrabalhoFinal.Infrastructure.Data.Configurations;

public class EditoraConfiguration : IEntityTypeConfiguration<Editora>
{
    public void Configure(EntityTypeBuilder<Editora> builder)
    {
        builder.ToTable("Editoras");

        // Chave primária
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        // Propriedades
        builder.Property(e => e.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Pais)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.AnoFundacao)
            .IsRequired();

        builder.Property(e => e.Site)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.DataCriacao)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        // Relacionamento 1:N com Manga
        builder.HasMany(e => e.Mangas)
            .WithOne(m => m.Editora)
            .HasForeignKey(m => m.EditoraId)
            .OnDelete(DeleteBehavior.Restrict); // Não permite deletar editora com mangás

        // Índices
        builder.HasIndex(e => e.Nome);
    }
}
