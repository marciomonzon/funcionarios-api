using Funcionarios.Domain.Entities.Base;

namespace Funcionarios.Domain.Entities
{
    public class Funcao : EntityBase
    {
        public Funcao(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<FuncionarioCLT> FuncionarioCLT { get; set; }
        public List<FuncionarioPJ> FuncionarioPJ { get; set; }
    }
}