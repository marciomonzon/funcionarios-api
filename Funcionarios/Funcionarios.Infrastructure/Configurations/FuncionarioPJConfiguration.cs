using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Infrastructure.Configurations
{
    public class FuncionarioPJConfiguration : IEntityTypeConfiguration<FuncionarioPJ>
    {
        public void Configure(EntityTypeBuilder<FuncionarioPJ> builder)
        {
            throw new NotImplementedException();
        }
    }
}
