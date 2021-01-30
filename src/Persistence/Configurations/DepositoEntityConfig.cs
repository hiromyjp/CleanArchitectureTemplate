using Hiro.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiro.Infrastructure.Persistence.Configurations
{
    class DepositoEntityConfig : IEntityTypeConfiguration<Deposito>
    {
        public void Configure(EntityTypeBuilder<Deposito> builder)
        {
            builder.ToTable("Depositos");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome).IsRequired().HasMaxLength(254);
            builder.Property(d => d.CodigoParceiro).IsRequired().HasMaxLength(64);
        }
    }
}
