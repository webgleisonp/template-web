using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Presentation.MapEndpoints.Clientes.Request;

public sealed record IncluirNovoClienteRequest(string Nome, Porte Porte);
