using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Repositories
{
    public class FuncaoRepository : IFuncaoRepository
    {
        private DataContext _context;

        public FuncaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Funcao funcao)
        {
            _context.Funcao.Add(funcao);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Funcao funcao)
        {
            _context.Set<Funcao>().Remove(funcao);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Funcao>> GetAll()
        {
            return await _context.Funcao
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Funcao> GetById(int id)
        {
            return await _context?.Funcao?
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Funcao funcao)
        {
            _context.Funcao.Update(funcao);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
