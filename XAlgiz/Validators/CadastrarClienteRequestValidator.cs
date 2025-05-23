using FluentValidation;
using XAlgiz.Dtos;

namespace XAlgiz.Validators;

public class CadastrarClienteRequestValidator : AbstractValidator<CadastrarClienteRequest>
{
    public CadastrarClienteRequestValidator()
    {
        RuleFor(r => r.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.");

        RuleFor(r => r.CpfCnpj)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("CPF ou CNPJ é obrigatório.")
            .Matches(@"^(\d{11}|[0-9A-Z]{14})$").WithMessage("CPF ou CNPJ inválido.")
            .Must(CpfCnpjEhValido).WithMessage("CPF ou CNPJ inválido.");

        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email inválido.");

        // Padrão flexível para incluir ou não DDI, mas sempre exigindo DDD
        RuleFor(r => r.Telefone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Matches(@"^(?:55)?(?:[1-9][0-9])(?:9?[0-9]{8})$").WithMessage("Telefone inválido.");
    }

    private static bool CpfCnpjEhValido(string cpfCnpj)
    {
        if (new string(cpfCnpj[0], cpfCnpj.Length) == cpfCnpj) return false;

        int[] primeiroPesos, segundoPesos;
        int primeiroDigitoVerificador, segundoDigitoVerificador;

        if (cpfCnpj.Length == 11)
        {
            primeiroPesos = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            segundoPesos = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];
            primeiroDigitoVerificador = cpfCnpj[9] - '0';
            segundoDigitoVerificador = cpfCnpj[10] - '0';
        }
        else
        {
            primeiroPesos = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            segundoPesos = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
            primeiroDigitoVerificador = cpfCnpj[12] - '0';
            segundoDigitoVerificador = cpfCnpj[13] - '0';
        }

        var primeiroCalculado = CalcularDigitoVerificador(cpfCnpj, primeiroPesos);
        if (primeiroCalculado != primeiroDigitoVerificador) return false;

        var segundoCalculado = CalcularDigitoVerificador(cpfCnpj, segundoPesos);
        return segundoCalculado == segundoDigitoVerificador;
    }

    private static int CalcularDigitoVerificador(string cpfCnpj, int[] pesos)
    {
        var soma = 0;
        for (var i = 0; i < pesos.Length; i++)
        {
            var digito = cpfCnpj[i] - '0';
            soma += pesos[i] * digito;
        }

        var resto = soma % 11;
        return resto < 2 ? 0 : 11 - resto;
    }
}