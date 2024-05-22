namespace DevIO.API.Controllers;

[Route("api/produtos")]
public class ProdutosController : MainController
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IProdutoService _produtoService;
    private readonly IMapper _mapper;
    public ProdutosController(IProdutoRepository produtoRepository,
                                IProdutoService produtoService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
    {
        _produtoRepository = produtoRepository;
        _produtoService = produtoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
    {
        return _mapper
               .Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
    {
        var produtoViewModel = await ObterProduto(id);

        return produtoViewModel == null ? (ActionResult<ProdutoViewModel>)NotFound() : (ActionResult<ProdutoViewModel>)produtoViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
    {
        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

        return RespostaPadrao(HttpStatusCode.Created, produtoViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
    {
        if (id != produtoViewModel.Id)
        {
            NotificarErro("Os Id´s informados do produto não são iguais.");
            return RespostaPadrao(HttpStatusCode.NoContent);
        }

        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        var produtoAtualizacao = await ObterProduto(id);

        // mapeando manual, temos o controle do que queremos atualiza de acordo com o negócio
        produtoAtualizacao.Nome = produtoViewModel.Nome;
        produtoAtualizacao.Descricao = produtoViewModel.Descricao;
        produtoAtualizacao.Valor = produtoViewModel.Valor;
        produtoAtualizacao.Ativo = produtoViewModel.Ativo;

        await _produtoService.Adicionar(_mapper.Map<Produto>(produtoAtualizacao));

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
    {
        var produto = await ObterProduto(id);

        if (produto == null) return NotFound();

        await _produtoService.Remover(id);

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    private async Task<ProdutoViewModel> ObterProduto(Guid id)
    {
        return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutosPorFornecedor(id));
    }
}