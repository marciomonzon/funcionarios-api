using AutoMapper;
using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Exceptions;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class CargoService : ServiceBase, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;

        public CargoService(ICargoRepository cargoRepository, IMapper mapper)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoDTO>> GetAll()
        {
            var cargosDoBanco = await _cargoRepository.GetAll();
            var cargos = _mapper.Map<IEnumerable<CargoDTO>>(cargosDoBanco);

            return cargos;
        }

        public async Task<CargoDTO> GetById(int id)
        {
            var cargo = await _cargoRepository.GetById(id);
            return _mapper.Map<CargoDTO>(cargo);
        }

        public async Task<ResponseDTO> Add(CargoDTO cargo)
        {
            try
            {
                var entidade = _mapper.Map<Cargo>(cargo);
                var resultado = await _cargoRepository.Add(entidade);

                return resultado ? 
                    CriarResponse(entidade.Id, "Cargo cadastrado com sucesso!")
                    : CriarResponse(0, "Cargo não cadastrado!");
            }
            catch (CargoException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Update(int id, CargoDTO cargo)
        {
            try
            {
                var entidade = _mapper.Map<Cargo>(cargo);
                var cargoEncontrado = await _cargoRepository.GetById(entidade.Id);

                if (cargoEncontrado == null) return CriarResponse(0, "Cargo não encontrado!");

                var resultado = await _cargoRepository.Update(entidade);

                return resultado ?
                    CriarResponse(entidade.Id, "Cargo atualizado com sucesso!")
                    : CriarResponse(0, "Cargo não atualizado!");
            }
            catch (CargoException ex)
            {
                throw ex;
            }
        }
        
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var cargoEncontrado = await _cargoRepository.GetById(id);
                if (cargoEncontrado == null) return CriarResponse(0, "Cargo não encontrado!");

                var resultado = await _cargoRepository.Delete(cargoEncontrado);

                return resultado ?
                    CriarResponse(id, "Cargo excluído com sucesso!")
                    : CriarResponse(0, "Cargo não excluído!");
            }
            catch (CargoException ex)
            {
                throw ex;
            }
        }
    }
}
