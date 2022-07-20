using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Interfaces.Repositories
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetAll();
        Task<Cargo> GetById(int id);
        Task<bool> Add(Cargo funcionario);
        Task<bool> Update(Cargo funcionario);
        Task<bool> Delete(Cargo id);
    }
}
