namespace XAlgiz.Models;

public class NotaFiscal
{
    public NotaFiscal()
    {
    }

    public NotaFiscal(int numero, DateOnly data, int clienteId, int servicoId)
    {
        Numero = numero;
        Data = data;
        ClienteId = clienteId;
        ServicoId = servicoId;
    }

    public int Id { get; set; }
    public int Numero { get; set; }
    public DateOnly Data { get; set; }
    public int ClienteId { get; set; }
    public int ServicoId { get; set; }
}