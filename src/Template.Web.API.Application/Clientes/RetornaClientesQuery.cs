using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class RetornaClientesQuery : IQuery<Result<IEnumerable<Cliente>>>
{
}
