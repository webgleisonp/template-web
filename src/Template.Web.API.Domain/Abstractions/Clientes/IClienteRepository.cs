using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Domain.Abstractions.Clientes;

public interface IClienteRepository
{
    Task<Cliente> IncluirNovoClienteAsync(Cliente novoCliente, CancellationToken cancellationToken);
    Task<Cliente?> AtualizaDadosClienteAsync(Guid id, string nome, Porte porte, CancellationToken cancellationToken);
    Task<Cliente> RetornaClientePeloIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Cliente>> RetornaClientesAsync(CancellationToken cancellationToken);
    Task<IEnumerable<Cliente>> RetornaClientesPeloNomeAsync(string nome, CancellationToken cancellationToken);
    Task ExcluirClienteAsync(Guid id, CancellationToken cancellationToken);
}
