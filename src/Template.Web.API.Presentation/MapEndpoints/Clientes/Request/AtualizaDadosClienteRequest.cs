using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Presentation.MapEndpoints.Clientes.Request;

public sealed record AtualizaDadosClienteRequest(string Nome, Porte Porte);
