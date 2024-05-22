namespace DevIO.Data.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Categorias");

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasColumnType("varchar(60)");

        // 1:N Categoria -> Produtos
        builder.HasMany(f => f.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(p => p.CategoriaId);
    }
}