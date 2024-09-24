using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Application.Clientes;

public sealed class IncluirNovoClienteCommand : ICommand
{
    public string Nome { get; init; }
    public Porte Porte { get; init; }
}
