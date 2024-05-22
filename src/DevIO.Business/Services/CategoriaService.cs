namespace DevIO.Business.Services;

public class CategoriaService : BaseService, ICategoriaService
{
    public readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository,
                            INotificador notificador) : base(notificador)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task Adicionar(Categoria categoria)
    {
        if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            return;

        if (_categoriaRepository.Buscar(f => f.Nome == categoria.Nome).Result.Any())
        {
            Notificar("Já existe uma categoria com o nome informado.");
            return;
        }

        await _categoriaRepository.Adicionar(categoria);
    }

    public async Task Atualizar(Categoria categoria)
    {
        if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            return;

        if (_categoriaRepository.Buscar(f => f.Nome == categoria.Nome
            && f.Id != categoria.Id).Result.Any())
        {
            Notificar("Já existe um categoria com o nome informado.");
            return;
        }
        await _categoriaRepository.Atualizar(categoria);
    }

    public async Task Remover(Guid id)
    {
        var categoria = await _categoriaRepository.ObterProdutoCategoria(id);

        if (categoria == null)
        {
            Notificar("Categoria não existe.");
            return;
        }

        if (categoria.Produtos.Any())
        {
            Notificar("A categoria possui produtos cadastrados.");
            return;
        }

        await _categoriaRepository.Remover(id);
    }

    public void Dispose()
    {
        _categoriaRepository?.Dispose();
    }
}

