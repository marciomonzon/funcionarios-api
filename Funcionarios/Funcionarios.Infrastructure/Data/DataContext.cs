using Funcionarios.Domain.Entities;
using Funcionarios.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new FuncaoConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioCLTConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioPJConfiguration());
        }

        public DbSet<FuncionarioCLT> FuncionarioCLT { get; set; }
        public DbSet<FuncionarioPJ> FuncionarioPJ { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
    }
}
