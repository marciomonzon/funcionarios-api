using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Interfaces.Repositories
{
    public interface IFuncionarioPJRepository
    {
        Task<IEnumerable<FuncionarioPJ>> GetAll();
        Task<FuncionarioPJ> GetById(int id);
        Task<bool> Add(FuncionarioPJ funcionario);
        Task<bool> Update(FuncionarioPJ funcionario);
        Task<bool> Delete(FuncionarioPJ id);
    }
}
