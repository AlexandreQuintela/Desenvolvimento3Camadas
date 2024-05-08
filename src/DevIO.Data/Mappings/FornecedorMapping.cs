using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Mappings;

public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
    {
        builder.HasKey(f => f.Id);

        builder.ToTable("Fornecedores");

        builder.Property(f => f.Nome)
            .IsRequired()
            .HasColumnName("varchar(200)");

        builder.Property(f => f.Documento)
            .IsRequired()
            .HasColumnName("varchar(14)");

        // 1:1 Fornecedor -> Endereço
        builder.HasOne(f => f.Endereco)
            .WithOne(e => e.Fornecedor);

        // 1:N Fornecedor -> Produtos
        builder.HasMany(f => f.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);
    }
}