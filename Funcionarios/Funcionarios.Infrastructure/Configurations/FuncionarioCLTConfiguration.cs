using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Funcionarios.Infrastructure.Configurations
{
    public class FuncionarioCLTConfiguration : IEntityTypeConfiguration<FuncionarioCLT>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCLT> builder)
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

            builder.HasOne(y => y.Cargo)
                   .WithMany(x => x.FuncionarioCLT)
                   .HasForeignKey(x => x.CargoId);

            builder.HasOne(y => y.Funcao)
                   .WithMany(x => x.FuncionarioCLT)
                   .HasForeignKey(x => x.FuncaoId);
        }
    }
}
