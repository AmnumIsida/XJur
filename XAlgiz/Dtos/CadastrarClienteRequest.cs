namespace XAlgiz.Dtos;

public record CadastrarClienteRequest(string Nome, string CpfCnpj, string Email, string Telefone);