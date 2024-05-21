using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(MeuDbContext context) : base(context)
    {
    }

    public async Task<Produto> ObterProdutoFornecedor(Guid id)
    {
        return await _Db.Produtos
                        .AsNoTracking()
                            .Include(p => p.Fornecedor)
                            .Include(c => c.Categoria)
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorCategoria(Guid categoriaId)
    {
        return await Buscar(c => c.CategoriaId == categoriaId);
    }

    public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
    {
        return await _Db.Produtos
                .AsNoTracking()
                    .Include(p => p.Fornecedor)
                    .Include(c => c.Categoria)
                    .OrderBy(p => p.Nome)
                    .ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
    {
        return await Buscar(p => p.FornecedorId == fornecedorId);
    }
}