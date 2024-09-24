using Microsoft.EntityFrameworkCore;
using Template.Web.API.Domain.Clientes;
using Template.Web.API.Infra.Data.Configurations;

namespace Template.Web.API.Infra.Data;

public sealed class TemplateDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientMapConfigurations());
    }
}
