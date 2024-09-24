using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class IncluirNovoClienteCommandHandler : ICommandHandler<IncluirNovoClienteCommand>
{
    private readonly IClienteRepository _repository;
    private readonly IVerificarClienteJaCadastradoPeloNomeService _service;

    public IncluirNovoClienteCommandHandler(IClienteRepository repository, IVerificarClienteJaCadastradoPeloNomeService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Result> Handle(IncluirNovoClienteCommand request, CancellationToken cancellationToken)
    {
        if (await _service.VerificarClienteJaCadastradoPeloNomeAsync(request.Nome, cancellationToken))
            return Result.Failure(new Error("IncluirNovoCliente", "Cliente já cadastrado"));

        var novoClienteResult = Cliente.CriarNovoUsuario(request.Nome, request.Porte);

        if (!novoClienteResult.IsSuccess)
            return novoClienteResult;

        await _repository.IncluirNovoClienteAsync(novoClienteResult.Value, cancellationToken);

        return novoClienteResult;
    }
}
