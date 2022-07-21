using AutoMapper;
using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Exceptions;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class FuncionarioCLTService : ServiceBase, IFuncionarioCLTService
    {
        private readonly ICargoService _cargoService;
        private readonly IFuncaoService _funcaoService;
        private readonly IFuncionarioCLTRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioCLTService(IFuncionarioCLTRepository funcionario,
                                     IMapper mapper,
                                     ICargoService cargoService,
                                     IFuncaoService funcaoService)
        {
            _funcionarioRepository = funcionario;
            _mapper = mapper;
            _cargoService = cargoService;
            _funcaoService = funcaoService;
        }

        public async Task<IEnumerable<FuncionarioCltDTO>> GetAll()
        {
            var funcionarios = await _funcionarioRepository.GetAll();

            var funcionariosMapeados = _mapper.Map<IEnumerable<FuncionarioCltDTO>>(funcionarios);

            return funcionariosMapeados;
        }

        public async Task<FuncionarioCltDTO> GetById(int id)
        {
            var funcionario = await _funcionarioRepository.GetById(id);

            var funcionarioMapeado = _mapper.Map<FuncionarioCltDTO>(funcionario);

            return funcionarioMapeado;
        }

        public async Task<ResponseDTO> Add(FuncionarioCltDTO funcionario)
        {
            try
            {
                var validacoes = ValidarCargoFuncao(funcionario.CargoId, funcionario.FuncaoId);
                if (validacoes.Erro)
                    return validacoes;

                var entidadeParaAdicionar = _mapper.Map<FuncionarioCLT>(funcionario);

                var retorno = await _funcionarioRepository.Add(entidadeParaAdicionar);

                return retorno ? CriarResponse(entidadeParaAdicionar.Id, "Funcionário cadastrado com sucesso!") :
                    CriarResponse(0, "Funcionário não foi cadastrado!");
            }
            catch (FuncionarioCLTException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Update(int id, FuncionarioCltDTO funcionario)
        {
            try
            {
                var validacoes = ValidarCargoFuncao(funcionario.CargoId, funcionario.FuncaoId);
                
                if (validacoes.Erro)
                    return validacoes;

                var existeFuncionario = await GetById(id);
                if (existeFuncionario == null)
                    return CriarResponse(0, "Funcionário informado não existe!");

                var entidadeParaAtualizar = _mapper.Map<FuncionarioCLT>(funcionario);
                var retorno = await _funcionarioRepository.Update(entidadeParaAtualizar);

                return retorno ? CriarResponse(entidadeParaAtualizar.Id, "Funcionário atualizado com sucesso!") :
                    CriarResponse(0, "Funcionário não foi atualizado!");
            }
            catch (FuncionarioCLTException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var entidade = await _funcionarioRepository.GetById(id);
                if (entidade == null)
                    return CriarResponse(0, "Funcionário informado não existe!");

                var retorno = await _funcionarioRepository.Delete(entidade);

                return retorno ? CriarResponse(entidade.Id, "Funcionário excluído com sucesso!") :
                    CriarResponse(0, "Funcionário não foi excluído!");
            }
            catch (FuncionarioCLTException ex)
            {
                throw ex;
            }
        }

        private ResponseDTO ValidarCargoFuncao(int cargoId, int funcaoId)
        {
            if (Task.FromResult(_cargoService.GetById(cargoId)) == null)
                return CriarResponse(0, "Cargo informado não existe!", true);

            if (Task.FromResult(_funcaoService.GetById(funcaoId)) == null)
                return CriarResponse(0, "Função informada não existe!", true);

            return new ResponseDTO{ Erro = false };
        }
    }
}
