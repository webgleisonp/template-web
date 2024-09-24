using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class RetornaClientesQueryHandler : IQueryHandler<RetornaClientesQuery, Result<IEnumerable<Cliente>>>
{
    private readonly IClienteRepository _repository;

    public RetornaClientesQueryHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<Cliente>>> Handle(RetornaClientesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.RetornaClientesAsync(cancellationToken);

        if (!result.Any())
            return Result.Failure<IEnumerable<Cliente>>(new Error("RetornaClientesVazio", "Não foram encontratos registros na base de dados"));
;
        return Result.Success(result);
    }
}
