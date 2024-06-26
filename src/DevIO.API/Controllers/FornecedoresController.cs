﻿namespace DevIO.API.Controllers;

[Route("api/fornecedores")]
public class FornecedoresController : MainController
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IFornecedorService _fornecedorService;
    private readonly IMapper _mapper;

    public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                    IFornecedorService fornecedorService,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
    {
        _fornecedorRepository = fornecedorRepository;
        _fornecedorService = fornecedorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
    {
        return _mapper
       .Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
    {
        var fornecedor = await ObterFornecedorProdutoEndereco(id);
        return fornecedor == null ? (ActionResult<FornecedorViewModel>)NotFound() : (ActionResult<FornecedorViewModel>)fornecedor;
    }

    [HttpPost]
    public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
    {
        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

        return RespostaPadrao(HttpStatusCode.Created, fornecedorViewModel);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
    {
        if (id != fornecedorViewModel.Id)
        {
            NotificarErro("Os Id´s informados do fornecedor são diferentes");
            return RespostaPadrao(HttpStatusCode.NoContent);
        }

        if (!ModelState.IsValid) return RespostaPadrao(ModelState);

        await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
    {
        await _fornecedorService.Remover(id);

        return RespostaPadrao(HttpStatusCode.NoContent);
    }

    private async Task<FornecedorViewModel> ObterFornecedorProdutoEndereco(Guid id)
    {
        return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
    }
}