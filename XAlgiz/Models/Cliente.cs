namespace XAlgiz.Models;

public class Cliente
{
    public Cliente(string nome, string cpfCnpj, string email, string telefone)
    {
        Nome = nome;
        CpfCnpj = cpfCnpj;
        Email = email;
        Telefone = telefone;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CpfCnpj { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}