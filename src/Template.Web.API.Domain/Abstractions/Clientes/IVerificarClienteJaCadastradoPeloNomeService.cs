namespace Template.Web.API.Domain.Abstractions.Clientes
{
    public interface IVerificarClienteJaCadastradoPeloNomeService
    {
        Task<bool> VerificarClienteJaCadastradoPeloNomeAsync(string nome, CancellationToken cancellationToken);
    }
}