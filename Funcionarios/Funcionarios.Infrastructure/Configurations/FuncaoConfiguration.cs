using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funcionarios.Infrastructure.Configurations
{
    public class FuncaoConfiguration : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn();

            builder.Property(f => f.Descricao)
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
