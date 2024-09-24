using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Application.Clientes;

public sealed class AtualizaDadosClienteCommand : ICommand
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Porte Porte { get; set; }
}
