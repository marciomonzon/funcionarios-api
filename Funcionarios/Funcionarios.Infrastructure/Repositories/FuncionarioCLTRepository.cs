using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Repositories
{
    public class FuncionarioCLTRepository : IFuncionarioCLTRepository
    {
        private DataContext _context;

        public FuncionarioCLTRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(FuncionarioCLT funcionario)
        {
            _context.FuncionarioCLT.Add(funcionario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(FuncionarioCLT funcionario)
        {
            _context.Set<FuncionarioCLT>().Remove(funcionario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<FuncionarioCLT>> GetAll()
        {
            return await _context.FuncionarioCLT
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<FuncionarioCLT> GetById(int id)
        {
            return await _context?.FuncionarioCLT?
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(FuncionarioCLT cargo)
        {
            _context.FuncionarioCLT.Update(cargo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
