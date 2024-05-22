namespace DevIO.Business.Models.Validations;

public class CategoriaValidation : AbstractValidator<Categoria>
{
    public CategoriaValidation()
    {
        RuleFor(f => f.Nome)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} não pode ser vazio.")
            .Length(2, 60)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
    }
}

