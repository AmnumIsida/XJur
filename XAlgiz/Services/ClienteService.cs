using XAlgiz.Data;
using XAlgiz.Dtos;
using XAlgiz.Models;

namespace XAlgiz.Services;

public class ClienteService(AppDbContext context) : BaseService(context)
{
    public CadastrarClienteResponse CadastrarCliente(CadastrarClienteRequest requisicao)
    {
        var cliente = new Cliente(
            requisicao.Nome,
            requisicao.CpfCnpj,
            requisicao.Email,
            requisicao.Telefone
        );
        Context.Clientes.Add(cliente);
        Context.SaveChanges();
        return new CadastrarClienteResponse(
            cliente.Id,
            cliente.Nome,
            cliente.CpfCnpj,
            cliente.Email,
            cliente.Telefone);
    }
}