using AutoMapper;
using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Entities;
using Funcionarios.Domain.Exceptions;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class FuncaoService : IFuncaoService
    {
        private readonly IFuncaoRepository _funcaoRepository;
        private readonly IMapper _mapper;

        public FuncaoService(IFuncaoRepository FuncaoRepository, IMapper mapper)
        {
            _funcaoRepository = FuncaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncaoDTO>> GetAll()
        {
            var FuncaosDoBanco = await _funcaoRepository.GetAll();
            var Funcaos = _mapper.Map<IEnumerable<FuncaoDTO>>(FuncaosDoBanco);

            return Funcaos;
        }

        public async Task<FuncaoDTO> GetById(int id)
        {
            var Funcao = await _funcaoRepository.GetById(id);
            return _mapper.Map<FuncaoDTO>(Funcao);
        }

        public async Task<ResponseDTO> Add(FuncaoDTO funcao)
        {
            try
            {
                var entidade = _mapper.Map<Funcao>(funcao);
                var resultado = await _funcaoRepository.Add(entidade);

                return resultado ?
                    CriarResponse(entidade.Id, "Função cadastrada com sucesso!")
                    : CriarResponse(0, "Função não cadastrada!");
            }
            catch (FuncaoException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Update(int id, FuncaoDTO dto)
        {
            try
            {
                var entidade = _mapper.Map<Funcao>(dto);
                var funcao = await _funcaoRepository.GetById(entidade.Id);

                if (funcao == null) return CriarResponse(0, "Função não encontrada!");

                var resultado = await _funcaoRepository.Update(entidade);

                return resultado ?
                    CriarResponse(entidade.Id, "Função atualizada com sucesso!")
                    : CriarResponse(0, "Função não atualizada!");
            }
            catch (FuncaoException ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var funcao = await _funcaoRepository.GetById(id);

                if (funcao == null) return CriarResponse(0, "Função não encontrada!");

                var resultado = await _funcaoRepository.Delete(funcao);

                return resultado ?
                    CriarResponse(id, "Função excluída com sucesso!")
                    : CriarResponse(0, "Função não excluída!");
            }
            catch (FuncaoException ex)
            {
                throw ex;
            }
        }

        private ResponseDTO CriarResponse(int id, string mensagem, string erro = "")
        {
            return new ResponseDTO
            {
                IdRegistro = id,
                Erro = erro,
                Mensagem = mensagem,
            };
        }
    }
}
