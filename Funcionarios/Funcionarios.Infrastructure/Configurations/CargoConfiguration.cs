using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funcionarios.Infrastructure.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn();

            builder.Property(f => f.CBO)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar");

            builder.Property(f => f.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar");
        }
    }
}
