using Template.Web.API.Domain.Clientes.Enumns;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Domain.Clientes;

public record Cliente
{
    public Cliente(Guid id, string nome, Porte porte)
    {
        Id = id;
        Nome = nome;
        Porte = porte;
    }

    private Cliente(string nome, Porte porte)
    {
        Nome = nome;
        Porte = porte;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Porte Porte { get; private set; }

    public static Result<Cliente> CriarNovoUsuario(string nome, Porte porte)
    {
        if (string.IsNullOrEmpty(nome))
            return Result.Failure<Cliente>(new Error("Cliente.Create", "É preciso informar o nome do cliente"));

        var novoCliente = new Cliente(nome, porte);

        return Result.Success(novoCliente);
    }

    public void SetNome(string nome)
    {
        Nome = nome;
    }

    public void SetPorte(Porte porte)
    {
        Porte = porte;
    }
}
