namespace DevIO.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Produtos");

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasColumnType("varchar(1000)");
    }
}