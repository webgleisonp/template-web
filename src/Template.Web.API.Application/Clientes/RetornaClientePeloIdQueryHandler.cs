using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class RetornaClientePeloIdQueryHandler : IQueryHandler<RetornaClientePeloIdQuery, Result<Cliente>>
{
    private readonly IClienteRepository _repository;

    public RetornaClientePeloIdQueryHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Cliente>> Handle(RetornaClientePeloIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.RetornaClientePeloIdAsync(request.Id, cancellationToken);

        if (result is null)
            return Result.Failure<Cliente>(new Error("RetornaClientePeloIdVazio", "Não foram encontratos registros na base de dados"));


        return Result.Success(result);
    }
}
