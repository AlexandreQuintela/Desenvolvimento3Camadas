namespace DevIO.Business.Interfaces;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<Categoria> ObterProdutoCategoria(Guid id);
}