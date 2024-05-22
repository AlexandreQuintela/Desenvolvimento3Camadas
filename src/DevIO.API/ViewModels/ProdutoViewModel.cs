namespace DevIO.API.ViewModels;

public class ProdutoViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    public decimal Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    public Guid FornecedorId { get; set; }

    public string NomeFornecedor { get; set; }
}
