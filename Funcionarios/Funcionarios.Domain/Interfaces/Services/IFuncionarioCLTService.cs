using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Interfaces.Services
{
    public interface IFuncionarioCLTService
    {
        Task<IEnumerable<FuncionarioCltDTO>> GetAll();
        Task<FuncionarioCltDTO> GetById(int id);
        void Add(FuncionarioCltDTO funcionario);
        void Update(FuncionarioCltDTO funcionario);
        Task Delete(int id);
    }
}
