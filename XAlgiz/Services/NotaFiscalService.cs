using XAlgiz.Data;
using XAlgiz.Dtos;
using XAlgiz.Exceptions;
using XAlgiz.Models;

namespace XAlgiz.Services;

public class NotaFiscalService(AppDbContext context) : BaseService(context)
{
    public EmitirNotaFiscalResponse EmitirNotaFiscal(EmitirNotaFiscalRequest requisicao)
    {
        var servico = Context.Servicos.Find(requisicao.ServicoId);
        if (servico == null) throw new ServicoNaoEncontradoException();

        var cliente = Context.Clientes.Find(servico.ClienteId);
        if (cliente == null) throw new ClienteNaoEncontradoException();

        if (Context.NotasFiscais.Any(n => n.ServicoId == requisicao.ServicoId))
            throw new ServicoJaPossuiNotaFiscalException();

        var ultimoNumero = Context.NotasFiscais.Any()
            ? Context.NotasFiscais.Max(n => n.Numero)
            : 0;

        var novoNumero = ultimoNumero + 1;

        var notaFiscal = new NotaFiscal(
            novoNumero,
            DateOnly.FromDateTime(DateTime.Now),
            cliente.Id,
            servico.Id
        );

        Context.NotasFiscais.Add(notaFiscal);
        Context.SaveChanges();

        return new EmitirNotaFiscalResponse(
            notaFiscal.Numero,
            notaFiscal.Data,
            cliente.Nome,
            cliente.CpfCnpj,
            cliente.Email,
            cliente.Telefone,
            servico.Descricao,
            servico.Valor,
            servico.Data
        );
    }
}