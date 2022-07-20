using Funcionarios.Domain.Entities.Base;

namespace Funcionarios.Domain.Entities
{
    public class Cargo : EntityBase
    {
        public Cargo(string cbo, string nome)
        {
            CBO = cbo;
            Nome = nome;
        }

        public string CBO { get; private set; }
        public string Nome { get; private set; }
        public List<FuncionarioCLT> FuncionarioCLT { get; set; }
        public List<FuncionarioPJ> FuncionarioPJ { get; set; }
    }
}
