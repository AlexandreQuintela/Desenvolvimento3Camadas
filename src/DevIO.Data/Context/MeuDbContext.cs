namespace DevIO.Data.Context;

public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        // quando model e rucupeda no banco pelo EF ele vai entregar uma instancia.
        // o ef monitora o que mudou e vai criar uma query para antender quando rodar o savechange
        // quando a gente leva para uma camada de API por exemplo uma view model (dto) existe um mapping 
        // da viewmodel para model ao fazer as modificações e remapear para outra model, o EF se perde
        // mas o mapeamento continua ligado, qual será o que vai persistir com o mesmo ID, ele vai se perder
        // ao voltar um outro com o mesmo ID.é legal deixar ligado quando não se usa muitos
        // dtos. É interessante deixar desligado(false) em nosso caso.
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var propriedades = modelBuilder.Model.GetEntityTypes()
                                                    .SelectMany(e => e.GetProperties()
                                                        .Where(p => p.ClrType == typeof(string)));
        foreach (var propiedade in propriedades)
        {
            propiedade.SetColumnType("varchar(150)");
        }

        // ao iniciar esse projeto (migration) pegar todos dbset setar para mapeamento.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

        var chavesExtragerias = modelBuilder.Model.GetEntityTypes()
                                                            .SelectMany(e => e.GetForeignKeys());
        foreach (var chave in chavesExtragerias)
        {
            // vamos impedir deletar filhos(cascata)
            chave.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries()
                                            .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("DataCadastro").IsModified = false;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
}