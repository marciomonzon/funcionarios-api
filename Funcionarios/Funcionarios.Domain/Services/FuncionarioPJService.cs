using AutoMapper;
using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Exceptions;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class FuncionarioPJService : ServiceBase, IFuncionarioPJService
    {
        private readonly IFuncionarioPJRepository _funcionarioRepository;
        private readonly IFuncaoService _funcaoService;
        private readonly IMapper _mapper;

        public FuncionarioPJService(IFuncionarioPJRepository funcionarioRepository, IFuncaoService funcaoService, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _funcaoService = funcaoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionarioPjDTO>> GetAll()
        {
            var funcionarios = await _funcionarioRepository.GetAll();

            var funcionariosMapeados = _mapper.Map<IEnumerable<FuncionarioPjDTO>>(funcionarios);

            return funcionariosMapeados;
        }

        public async Task<FuncionarioPjDTO> GetById(int id)
        {
            var funcionario = await _funcionarioRepository.GetById(id);

            var funcionarioMapeado = _mapper.Map<FuncionarioPjDTO>(funcionario);

            return funcionarioMapeado;
        }

        public async Task<ResponseDTO> Add(FuncionarioPjDTO funcionario)
        {
            try
            {
                var validacoes = ValidarFuncao(funcionario.FuncaoId);
                if (validacoes.Erro)
                    return validacoes;

                var entidadeParaAdicionar = _mapper.Map<FuncionarioPJ>(funcionario);

                var retorno = await _funcionarioRepository.Add(entidadeParaAdicionar);

                return retorno ? CriarResponse(entidadeParaAdicionar.Id, "Funcionário cadastrado com sucesso!") :
                    CriarResponse(0, "Funcionário não foi cadastrado!");
            }
            catch (FuncionarioPJException ex)
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
            catch (FuncionarioPJException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Update(int id, FuncionarioPjDTO funcionario)
        {
            try
            {
                var validacoes = ValidarFuncao(funcionario.FuncaoId);

                if (validacoes.Erro)
                    return validacoes;

                var existeFuncionario = await GetById(id);
                if (existeFuncionario == null)
                    return CriarResponse(0, "Funcionário informado não existe!");

                var entidadeParaAtualizar = _mapper.Map<FuncionarioPJ>(funcionario);
                var retorno = await _funcionarioRepository.Update(entidadeParaAtualizar);

                return retorno ? CriarResponse(entidadeParaAtualizar.Id, "Funcionário atualizado com sucesso!") :
                    CriarResponse(0, "Funcionário não foi atualizado!");
            }
            catch (FuncionarioPJException ex)
            {
                throw ex;
            }
        }

        private ResponseDTO ValidarFuncao(int funcaoId)
        {
            if (Task.FromResult(_funcaoService.GetById(funcaoId)) == null)
                return CriarResponse(0, "Função informada não existe!", true);

            return new ResponseDTO { Erro = false };
        }
    }
}
