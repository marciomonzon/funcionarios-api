using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Interfaces.Repositories
{
    public interface IFuncaoRepository
    {
        Task<IEnumerable<Funcao>> GetAll();
        Task<Funcao> GetById(int id);
        Task<bool> Add(Funcao funcao);
        Task<bool> Update(Funcao funcao);
        Task<bool> Delete(Funcao id);
    }
}
