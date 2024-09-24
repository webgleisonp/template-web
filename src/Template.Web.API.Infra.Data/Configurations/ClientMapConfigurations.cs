using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Web.API.Domain.Clientes;

namespace Template.Web.API.Infra.Data.Configurations;

public sealed class ClientMapConfigurations : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Porte).IsRequired();
    }
}
