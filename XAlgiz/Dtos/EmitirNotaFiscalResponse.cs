namespace XAlgiz.Dtos;

public record EmitirNotaFiscalResponse(
    int Numero,
    DateOnly DataDeEmissao,
    string ClienteNome,
    string ClienteCpfCnpj,
    string ClienteEmail,
    string ClienteTelefone,
    string ServicoDescricao,
    decimal ServicoValor,
    DateOnly ServicoData);