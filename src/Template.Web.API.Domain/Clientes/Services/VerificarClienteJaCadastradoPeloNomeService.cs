using Template.Web.API.Domain.Abstractions.Clientes;

namespace Template.Web.API.Domain.Clientes.Services;

public sealed class VerificarClienteJaCadastradoPeloNomeService : IVerificarClienteJaCadastradoPeloNomeService
{
    private readonly IClienteRepository _repository;

    public VerificarClienteJaCadastradoPeloNomeService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> VerificarClienteJaCadastradoPeloNomeAsync(string nome, CancellationToken cancellationToken)
    {
        var clientes = await _repository.RetornaClientesPeloNomeAsync(nome, cancellationToken);

        return clientes.Any();
    }
}
