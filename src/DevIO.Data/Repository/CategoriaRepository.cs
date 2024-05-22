
namespace DevIO.Data.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(MeuDbContext context) : base(context)
    {
    }

    public async Task<Categoria> ObterProdutoCategoria(Guid id)
    {
        return await _Db.Categorias.AsNoTracking()
            .Include(p => p.Produtos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}