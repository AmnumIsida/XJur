namespace XAlgiz.Models;

public class Servico
{
    public Servico()
    {
    }

    public Servico(int clienteId, string descricao, decimal valor, DateOnly data)
    {
        ClienteId = clienteId;
        Descricao = descricao;
        Valor = valor;
        Data = data;
    }

    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateOnly Data { get; set; }
    public int ClienteId { get; set; }
}