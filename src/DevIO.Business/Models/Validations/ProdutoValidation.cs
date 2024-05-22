﻿namespace DevIO.Business.Models.Validations;

public class ProdutoValidation : AbstractValidator<Produto>
{
    public ProdutoValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido.")
            .Length(2, 200)
            .WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLeangth} caracteres.");
        RuleFor(c => c.Descricao)
            .NotEmpty()
            .WithMessage("O campo {PropertyName} precisa ser fornecido.")
            .Length(2, 1000)
            .WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLeangth} caracteres.");
        RuleFor(c => c.Valor)
            .GreaterThan(0)
            .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}.");
    }
}