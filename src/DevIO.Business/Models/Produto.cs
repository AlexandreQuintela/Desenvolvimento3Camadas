namespace DevIO.Business.Models;

public class Produto : Entity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }

    // Relação EF
    public Fornecedor Fornecedor { get; set; } = null!;
    public Guid FornecedorId { get; set; }

    public Categoria Categoria { get; set; } = null!;
    public Guid CategoriaId { get; set; }
}