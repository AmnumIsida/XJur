using FluentValidation;
using XAlgiz.Dtos;

namespace XAlgiz.Validators;

public class EmitirNotaFiscalRequestValidator : AbstractValidator<EmitirNotaFiscalRequest>
{
    public EmitirNotaFiscalRequestValidator()
    {
        RuleFor(r => r.ServicoId)
            .GreaterThan(0).WithMessage("Id do serviço inválido.");
    }
}