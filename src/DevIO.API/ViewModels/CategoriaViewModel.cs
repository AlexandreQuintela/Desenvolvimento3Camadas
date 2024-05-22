namespace DevIO.API.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} Caracteres.")]
        public String Nome { get; set; } = string.Empty;
    }
}