namespace XAlgiz.Dtos;

public record CadastrarServicoRequest(int ClientId, string Descricao, decimal Valor, DateOnly Data);