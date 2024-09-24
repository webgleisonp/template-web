using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Domain.Clientes.Enumns;

namespace Template.Web.API.Infra.Data.Repository;

public sealed class ClienteRepository : IClienteRepository
{
    private readonly TemplateDbContext _context;

    public ClienteRepository(TemplateDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("Desenvolvimento")!;
    }

    private readonly string _connectionString;

    public async Task<Cliente> IncluirNovoClienteAsync(Cliente novoCliente, CancellationToken cancellationToken)
    {
        await _context.Clientes.AddAsync(novoCliente, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return novoCliente;
    }

    public async Task<IEnumerable<Cliente>> RetornaClientesAsync(CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_connectionString);

        var clientes = await connection.QueryAsync<Cliente>("SELECT Id, Nome, Porte FROM Clientes");

        return clientes;
    }

    public async Task<IEnumerable<Cliente>> RetornaClientesPeloNomeAsync(string nome, CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_connectionString);

        var parameters = new
        {
            Nome = nome
        };

        var clientes = await connection.QueryAsync<Cliente>("SELECT * FROM Clientes WHERE Nome = @Nome", parameters);

        return clientes;
    }

    public async Task<Cliente> RetornaClientePeloIdAsync(Guid id, CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_connectionString);

        var parameters = new
        {
            Id = id
        };

        var clientes = await connection.QuerySingleOrDefaultAsync<Cliente>("SELECT * FROM Clientes WHERE Id = @Id", parameters);

        return clientes;
    }

    public async Task<Cliente?> AtualizaDadosClienteAsync(Guid id, string nome, Porte porte, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (cliente is null) return null;

        cliente.SetNome(nome);
        cliente.SetPorte(porte);

        await _context.SaveChangesAsync(cancellationToken);

        return cliente;
    }

    public async Task ExcluirClienteAsync(Guid id, CancellationToken cancellationToken)
    {
        var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (cliente is null) return;

        _context.Clientes.Remove(cliente);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
