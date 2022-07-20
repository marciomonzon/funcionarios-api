using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Interfaces.Services
{
    public interface IFuncaoService
    {
        Task<IEnumerable<FuncaoDTO>> GetAll();
        Task<FuncaoDTO> GetById(int id);
        Task<ResponseDTO> Add(FuncaoDTO funcao);
        Task<ResponseDTO> Update(int id, FuncaoDTO funcao);
        Task<ResponseDTO> Delete(int id);
    }
}
