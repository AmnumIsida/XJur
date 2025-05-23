using FluentValidation;
using XAlgiz.Dtos;

namespace XAlgiz.Validators;

public class CadastrarServicoRequestValidator : AbstractValidator<CadastrarServicoRequest>
{
    public CadastrarServicoRequestValidator()
    {
        RuleFor(r => r.ClienteId)
            .GreaterThan(0).WithMessage("Id do cliente inválido.");

        RuleFor(r => r.Descricao)
            .NotEmpty().WithMessage("Descrição é obrigatória.");

        RuleFor(r => r.Valor)
            .GreaterThan(0).WithMessage("Valor menor que zero.");
    }
}