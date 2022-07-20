using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<FuncionarioCLT> FuncionarioCLT { get; set; }
        public DbSet<FuncionarioPJ> FuncionarioPJ { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
    }
}
