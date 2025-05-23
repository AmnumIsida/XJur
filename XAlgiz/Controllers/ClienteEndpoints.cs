using FluentValidation;
using XAlgiz.Dtos;
using XAlgiz.Services;

namespace XAlgiz.Controllers;

public static class ClienteEndpoints
{
    public static void MapClienteEndpoints(this WebApplication app)
    {
        app.MapPost("/clientes",
                (CadastrarClienteRequest request, ClienteService service,
                    IValidator<CadastrarClienteRequest> validator) =>
                {
                    var validation = validator.Validate(request);
                    if (!validation.IsValid)
                        return Results.BadRequest(validation.Errors.Select(e => e.ErrorMessage));

                    try
                    {
                        return Results.Ok(service.CadastrarCliente(request));
                    }
                    catch
                    {
                        return Results.StatusCode(500);
                    }
                })
            .RequireAuthorization()
            .WithName("CadastrarCliente")
            .WithTags("Clientes")
            .Produces<CadastrarClienteResponse>()
            .Produces<IEnumerable<string>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }
}