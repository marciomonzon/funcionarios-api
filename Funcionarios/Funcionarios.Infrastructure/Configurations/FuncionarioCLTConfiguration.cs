using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funcionarios.Infrastructure.Configurations
{
    public class FuncionarioCLTConfiguration : IEntityTypeConfiguration<FuncionarioCLT>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCLT> builder)
        {
            builder.HasKey(x => x.Id);
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
                    .HasColumnType("decimal");
            builder.Property(f => f.DataNascimento)
                    .IsRequired();
        }
    }
}
