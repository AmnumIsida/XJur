namespace XAlgiz.Dtos;

public record CadastrarServicoRequest(int ClienteId, string Descricao, decimal Valor, DateOnly Data);