using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Interfaces.Repositories
{
    public interface IFuncionarioCLTRepository
    {
        Task<IEnumerable<FuncionarioCLT>> GetAll();
        Task<FuncionarioCLT> GetById(int id);
        Task<bool> Add(FuncionarioCLT funcionario);
        Task<bool> Update(FuncionarioCLT funcionario);
        Task<bool> Delete(FuncionarioCLT funcionario);
    }
}
