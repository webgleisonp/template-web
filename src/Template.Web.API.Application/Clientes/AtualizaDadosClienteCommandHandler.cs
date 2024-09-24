using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class AtualizaDadosClienteCommandHandler : ICommandHandler<AtualizaDadosClienteCommand>
{
    private readonly IClienteRepository _repository;

    public AtualizaDadosClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(AtualizaDadosClienteCommand request, CancellationToken cancellationToken)
    {
        var clienteAtualizado = await _repository.AtualizaDadosClienteAsync(request.Id, request.Nome, request.Porte, cancellationToken);

        return Result.Success(clienteAtualizado);
    }
}
