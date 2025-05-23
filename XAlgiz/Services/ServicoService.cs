using XAlgiz.Data;
using XAlgiz.Dtos;
using XAlgiz.Exceptions;
using XAlgiz.Models;

namespace XAlgiz.Services;

public class ServicoService(AppDbContext context) : BaseService(context)
{
    public CadastrarServicoResponse CadastrarServico(CadastrarServicoRequest requisicao)
    {
        var cliente = Context.Clientes.Find(requisicao.ClientId);
        if (cliente == null) throw new ClienteNaoEncontradoException();

        var servico = new Servico(cliente.Id, requisicao.Descricao, requisicao.Valor, requisicao.Data);

        Context.Servicos.Add(servico);
        Context.SaveChanges();

        return new CadastrarServicoResponse(
            servico.Id,
            servico.ClienteId,
            servico.Descricao,
            servico.Valor,
            servico.Data
        );
    }
}