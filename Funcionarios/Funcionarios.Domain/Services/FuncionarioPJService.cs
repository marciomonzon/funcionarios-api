using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class FuncionarioPJService : IFuncionarioPJService
    {
        private readonly IFuncionarioPJRepository _funcionario;

        public FuncionarioPJService(IFuncionarioPJRepository funcionario)
        {
            _funcionario = funcionario;
        }

        public void Add(FuncionarioCltDTO funcionario)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncionarioCltDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCltDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(FuncionarioCltDTO funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
