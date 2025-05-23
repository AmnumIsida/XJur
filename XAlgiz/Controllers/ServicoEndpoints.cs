using FluentValidation;
using XAlgiz.Dtos;
using XAlgiz.Exceptions;
using XAlgiz.Services;

namespace XAlgiz.Controllers;

public static class ServicoEndpoints
{
    public static void MapServicoEndpoints(this WebApplication app)
    {
        app.MapPost("/servicos",
                (CadastrarServicoRequest request, ServicoService service,
                    IValidator<CadastrarServicoRequest> validator) =>
                {
                    var validation = validator.Validate(request);
                    if (!validation.IsValid)
                        return Results.BadRequest(validation.Errors.Select(e => e.ErrorMessage));

                    try
                    {
                        return Results.Ok(service.CadastrarServico(request));
                    }
                    catch (ClienteNaoEncontradoException)
                    {
                        return Results.BadRequest(new[] { "Cliente não encontrado." });
                    }
                    catch
                    {
                        return Results.StatusCode(500);
                    }
                })
            .RequireAuthorization()
            .WithName("CadastrarServico")
            .WithTags("Serviços")
            .Produces<CadastrarServicoResponse>()
            .Produces<IEnumerable<string>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }
}