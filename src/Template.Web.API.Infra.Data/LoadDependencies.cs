using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Web.API.Domain.Abstractions.Clientes;
using Template.Web.API.Infra.Data.Repository;

namespace Template.Web.API.Infra.Data;

public static class LoadDependencies
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TemplateDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Desenvolvimento"));
        });

        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}
