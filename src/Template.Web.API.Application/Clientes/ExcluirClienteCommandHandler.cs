using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Clientes;

public sealed class ExcluirClienteCommandHandler : ICommandHandler<ExcluirClienteCommand>
{
    private readonly IClienteRepository _repository;

    public ExcluirClienteCommandHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
    {
        await _repository.ExcluirClienteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
