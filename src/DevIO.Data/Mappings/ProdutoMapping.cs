using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Produtos");

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnName("varchar(200)");

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnName("varchar(1000)");
    }
}