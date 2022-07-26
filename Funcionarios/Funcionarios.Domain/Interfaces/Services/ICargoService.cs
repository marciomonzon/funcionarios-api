using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Interfaces.Services
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoDTO>> GetAll();
        Task<CargoDTO> GetById(int id);
        Task<ResponseDTO> Add(CargoDTO cargo);
        Task<ResponseDTO> Update(int id, CargoDTO cargo);
        Task<ResponseDTO> Delete(int id);
    }
}
