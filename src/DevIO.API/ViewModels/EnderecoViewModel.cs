namespace DevIO.API.ViewModels;

public class EnderecoViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Logradouro { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Numero { get; set; }
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Cep { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Bairro { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Cidade { get; set; }

    [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
    public string? Estado { get; set; }

    public Guid FornecedorID { get; set; }
}
