using FluentValidation;
using XAlgiz.Dtos;
using XAlgiz.Exceptions;
using XAlgiz.Services;

namespace XAlgiz.Controllers;

public static class NotaFiscalEndpoints
{
    public static void MapNotaFiscalEndpoints(this WebApplication app)
    {
        app.MapPost("/notas-fiscais",
                (EmitirNotaFiscalRequest request, NotaFiscalService service,
                    IValidator<EmitirNotaFiscalRequest> validator) =>
                {
                    var validation = validator.Validate(request);
                    if (!validation.IsValid)
                        return Results.BadRequest(validation.Errors.Select(e => e.ErrorMessage));

                    try
                    {
                        return Results.Ok(service.EmitirNotaFiscal(request));
                    }
                    catch (ServicoJaPossuiNotaFiscalException)
                    {
                        return Results.BadRequest(new[] { "Serviço já possui nota fiscal associada." });
                    }
                    catch (ServicoNaoEncontradoException)
                    {
                        return Results.BadRequest(new[] { "Serviço não encontrado." });
                    }
                    catch (ClienteNaoEncontradoException)
                    {
                        return Results.BadRequest(new[] { "Cliente não encontrado." });
                    }
                    catch (Exception)
                    {
                        return Results.StatusCode(500);
                    }
                })
            .RequireAuthorization()
            .WithName("EmitirNotaFiscal")
            .WithTags("Notas Fiscais")
            .Produces<EmitirNotaFiscalResponse>()
            .Produces<IEnumerable<string>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }
}