using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Interfaces.Services
{
    public interface IFuncionarioPJService
    {
        Task<IEnumerable<FuncionarioPjDTO>> GetAll();
        Task<FuncionarioPjDTO> GetById(int id);
        Task<ResponseDTO> Add(FuncionarioPjDTO funcionario);
        Task<ResponseDTO> Update(int id, FuncionarioPjDTO funcionario);
        Task<ResponseDTO> Delete(int id);
    }
}
