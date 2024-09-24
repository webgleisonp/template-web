using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class RetornaClientePeloIdQuery : IQuery<Result<Cliente>>
{
    public Guid Id { get; init; }
}
