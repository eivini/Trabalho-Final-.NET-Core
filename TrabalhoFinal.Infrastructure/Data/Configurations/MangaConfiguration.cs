using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrabalhoFinal.Domain.Entities;

namespace TrabalhoFinal.Infrastructure.Data.Configurations;

public class MangaConfiguration : IEntityTypeConfiguration<Manga>
{
    public void Configure(EntityTypeBuilder<Manga> builder)
    {
        builder.ToTable("Mangas");

        // Chave primária
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();

        // Propriedades
        builder.Property(m => m.Titulo)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.Autor)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.Genero)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Volumes)
            .IsRequired();

        builder.Property(m => m.AnoPublicacao)
            .IsRequired();

        builder.Property(m => m.EmAndamento)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(m => m.Preco)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.Property(m => m.DataCriacao)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        // Chave estrangeira explícita (requisito obrigatório)
        builder.Property(m => m.EditoraId)
            .IsRequired();

        // Relacionamento N:1 com Editora
        builder.HasOne(m => m.Editora)
            .WithMany(e => e.Mangas)
            .HasForeignKey(m => m.EditoraId)
            .OnDelete(DeleteBehavior.Restrict);

        // Índices
        builder.HasIndex(m => m.Titulo);
        builder.HasIndex(m => m.EditoraId);
    }
}
