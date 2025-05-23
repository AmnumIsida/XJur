namespace XAlgiz.Dtos;

public record CadastrarServicoResponse(int Id, int ClientId, string Descricao, decimal Valor, DateOnly Data);