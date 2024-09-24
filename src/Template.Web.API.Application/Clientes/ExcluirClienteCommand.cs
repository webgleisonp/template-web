using Template.Web.API.Application.Abstractions;

namespace Template.Web.API.Application.Clientes;

public sealed class ExcluirClienteCommand : ICommand
{
    public Guid Id { get; set; }
}
