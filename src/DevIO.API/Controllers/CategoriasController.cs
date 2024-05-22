namespace DevIO.API.Controllers;

[Route("api/categorias")]
public class CategoriasController : MainController
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly ICategoriaService _categoriaService;
    private readonly IMapper _mapper;
    public CategoriasController(ICategoriaRepository categoriaRepository,
                                    ICategoriaService categoriaService,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
    {
        _categoriaRepository = categoriaRepository;
        _categoriaService = categoriaService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
    {
        return _mapper
       .Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoriaViewModel>> ObterPorId(Guid id)
    {
        var categoria = await ObterProdutoCategoria(id);
        return categoria == null ? (ActionResult<CategoriaViewModel>)NotFound() : (ActionResult<CategoriaViewModel>)categoria;
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
    {
        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

        return RespostaPadrao(HttpStatusCode.Created, categoriaViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Atualizar(Guid id, CategoriaViewModel categoriaViewModel)
    {
        if (id != categoriaViewModel.Id)
        {
            NotificarErro("Os Id´s informados da categoria são diferentes");
            return RespostaPadrao(HttpStatusCode.NoContent);
        }

        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
    {
        await _categoriaService.Remover(id);

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    private async Task<CategoriaViewModel> ObterProdutoCategoria(Guid id)
    {
        return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterProdutoCategoria(id));
    }
}
