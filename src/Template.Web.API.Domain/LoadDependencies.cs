using Microsoft.Extensions.DependencyInjection;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Domain.Clientes.Services;

namespace Template.Web.API.Domain;

public static class LoadDependencies
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IVerificarClienteJaCadastradoPeloNomeService, VerificarClienteJaCadastradoPeloNomeService>();

        return services;
    }
}
