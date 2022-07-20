using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Repositories
{
    public class FuncionarioPJRepository : IFuncionarioPJRepository
    {
        private DataContext _context;

        public FuncionarioPJRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(FuncionarioPJ funcionario)
        {
            _context.FuncionarioPJ.Add(funcionario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(FuncionarioPJ funcionario)
        {
            _context.Set<FuncionarioPJ>().Remove(funcionario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<FuncionarioPJ>> GetAll()
        {
            return await _context.FuncionarioPJ
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<FuncionarioPJ> GetById(int id)
        {
            return await _context?.FuncionarioPJ?
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(FuncionarioPJ cargo)
        {
            _context.FuncionarioPJ.Update(cargo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
