namespace DevIO.Business.Models;
public class Categoria : Entity
{
    public String Nome { get; set; } = string.Empty;
    public IEnumerable<Produto> Produtos { get; set; }
}