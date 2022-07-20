using Funcionarios.Domain.Entities.Base;

namespace Funcionarios.Domain.Entities
{
    public class FuncionarioPJ : FuncionarioBase
    {
        public decimal Salario { get; set; }
        public int FuncaoId { get; private set; }
        public Funcao Funcao { get; private set; }

        public FuncionarioPJ(string nome, string email, DateTime dataNascimento)
            : base(nome, email, dataNascimento)
        {
        }

        public void SetFuncao(int funcao)
        {
            FuncaoId = funcao;
        }
    }
}
