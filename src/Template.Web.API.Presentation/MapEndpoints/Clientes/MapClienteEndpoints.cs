using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Template.Web.API.Application.Clientes;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;
using Template.Web.API.Presentation.MapEndpoints.Abstractions;
using Template.Web.API.Presentation.MapEndpoints.Clientes.Request;

namespace Template.Web.API.Presentation.MapEndpoints.Clientes;

public class MapClienteEndpoints : IEndpointMap
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("cliente", RetornaClientes)
            .Produces<Result<IEnumerable<Cliente>>>()
            .Produces(204)
            .Produces<Result<IEnumerable<Cliente>>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .MapToApiVersion(1);

        app.MapGet("cliente/{id}", RetornaClientePeloId)
            .Produces<Result<Cliente>>()
            .Produces(204)
            .Produces<Result<Cliente>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .MapToApiVersion(1);

        app.MapPut("cliente/{id}", AtualizaDadosCliente)
            .Produces<Result>(204)
            .Produces<Result<Cliente>>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .MapToApiVersion(1);

        app.MapPost("cliente", IncluirNovoCliente)
            .Produces<Result<Cliente>>(201)
            .Produces<Result>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .MapToApiVersion(1);

        app.MapDelete("cliente/{id}", ExcluirCliente)
            .Produces<Result>()
            .Produces<Result>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError)
            .MapToApiVersion(1);
    }

    public static async Task<IResult> RetornaClientes(ISender sender, CancellationToken cancellationToken)
    {
        var query = new RetornaClientesQuery();

        var result = await sender.Send(query, cancellationToken);

        if (!result.IsSuccess && result.Error is not null)
        {
            if (result.Error.Code == "RetornaClientesVazio")
                return Results.NoContent();

            var problemDetail = new ProblemDetails
            {
                Title = result.Error.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = result.Error.Description
            };

            return Results.Problem(problemDetail);
        }

        return Results.Ok(result);
    }

    public static async Task<IResult> RetornaClientePeloId(ISender sender, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new RetornaClientePeloIdQuery()
        {
            Id = id
        };

        var result = await sender.Send(query, cancellationToken);

        if (!result.IsSuccess && result.Error is not null)
        {
            if (result.Error.Code == "RetornaClientePeloIdVazio")
                return Results.NoContent();

            var problemDetail = new ProblemDetails
            {
                Title = result.Error.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = result.Error.Description
            };

            return Results.Problem(problemDetail);
        }

        return Results.Ok(result);
    }

    public static async Task<IResult> IncluirNovoCliente(ISender sender, [FromBody] IncluirNovoClienteRequest request, CancellationToken cancellationToken)
    {
        var command = new IncluirNovoClienteCommand
        {
            Nome = request.Nome,
            Porte = request.Porte,
        };

        var result = await sender.Send(command, cancellationToken);

        if (!result.IsSuccess && result.Error is not null)
        {
            var problemDetail = new ProblemDetails
            {
                Title = result.Error.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = result.Error.Description
            };

            return Results.Problem(problemDetail);
        }

        return Results.Created();
    }

    public static async Task<IResult> AtualizaDadosCliente(ISender sender, [FromRoute] Guid id, [FromBody] AtualizaDadosClienteRequest request, CancellationToken cancellationToken)
    {
        var command = new AtualizaDadosClienteCommand
        {
            Id = id,
            Nome = request.Nome,
            Porte = request.Porte,
        };

        var result = await sender.Send(command, cancellationToken);

        if (!result.IsSuccess && result.Error is not null)
        {
            var problemDetail = new ProblemDetails
            {
                Title = result.Error.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = result.Error.Description
            };

            return Results.Problem(problemDetail);
        }

        return Results.NoContent();
    }

    public static async Task<IResult> ExcluirCliente(ISender sender, [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new ExcluirClienteCommand
        {
            Id = id
        };

        var result = await sender.Send(command, cancellationToken);

        if (!result.IsSuccess && result.Error is not null)
        {
            var problemDetail = new ProblemDetails
            {
                Title = result.Error.Code,
                Status = StatusCodes.Status400BadRequest,
                Detail = result.Error.Description
            };

            return Results.Problem(problemDetail);
        }

        return Results.Ok();
    }
}
