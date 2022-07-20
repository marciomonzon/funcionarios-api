using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private DataContext _context;

        public CargoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Cargo cargo)
        {
            _context.Cargo.Add(cargo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Cargo cargo)
        {
            _context.Set<Cargo>().Remove(cargo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await _context.Cargo
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Cargo> GetById(int id)
        {
            return await _context?.Cargo?
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Cargo cargo)
        {
            _context.Cargo.Update(cargo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
