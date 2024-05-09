using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context;

public class MeuDbContext : DbContext
{
    public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
    {
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

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
}