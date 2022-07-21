using Funcionarios.Domain.DTO;

namespace Funcionarios.Domain.Services
{
    public abstract class ServiceBase
    {
        protected ResponseDTO CriarResponse(int id, string mensagem, bool erro = false)
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
