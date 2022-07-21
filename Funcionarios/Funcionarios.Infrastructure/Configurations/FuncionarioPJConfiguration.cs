using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funcionarios.Infrastructure.Configurations
{
    public class FuncionarioPJConfiguration : IEntityTypeConfiguration<FuncionarioPJ>
    {
        public void Configure(EntityTypeBuilder<FuncionarioPJ> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn();

            builder.Property(f => f.Nome)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("varchar");

            builder.Property(f => f.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnType("varchar");

            builder.Property(f => f.Salario)
                    .IsRequired()
                    .HasColumnType("decimal")
                    .HasPrecision(18, 2);

            builder.Property(f => f.DataNascimento)
                    .IsRequired();

            builder.HasOne(y => y.Funcao)
                   .WithMany(x => x.FuncionarioPJ)
                   .HasForeignKey(x => x.FuncaoId);
        }
    }
}
