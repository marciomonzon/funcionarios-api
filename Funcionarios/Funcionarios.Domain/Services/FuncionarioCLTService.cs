using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;

namespace Funcionarios.Domain.Services
{
    public class FuncionarioCLTService : IFuncionarioCLTService
    {
        private readonly IFuncionarioCLTRepository _funcionarioRepository;

        public FuncionarioCLTService(IFuncionarioCLTRepository funcionario)
        {
            _funcionarioRepository = funcionario;
        }

        public Task<IEnumerable<FuncionarioCltDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCltDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(FuncionarioCltDTO funcionario)
        {
            throw new NotImplementedException();
        }

        public void Update(FuncionarioCltDTO funcionario)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
