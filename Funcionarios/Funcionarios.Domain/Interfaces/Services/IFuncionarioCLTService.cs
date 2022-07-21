using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Interfaces.Services
{
    public interface IFuncionarioCLTService
    {
        Task<IEnumerable<FuncionarioCltDTO>> GetAll();
        Task<FuncionarioCltDTO> GetById(int id);
        Task<ResponseDTO> Add(FuncionarioCltDTO funcionario);
        Task<ResponseDTO> Update(int id, FuncionarioCltDTO funcionario);
        Task<ResponseDTO> Delete(int id);
    }
}
