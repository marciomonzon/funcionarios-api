using Funcionarios.Domain.Entities.Base;

namespace Funcionarios.Domain.Entities
{
    public class FuncionarioCLT : FuncionarioBase
    {
        public decimal Salario { get; private set; }
        public int CargoId { get; private set; }
        public Cargo Cargo { get; private set; }
        public int FuncaoId { get; private set; }
        public Funcao Funcao { get; private set; }

        public FuncionarioCLT(string nome, string email, DateTime dataNascimento) 
            : base(nome, email, dataNascimento)
        {
        }

        public void SetSalario(decimal salario)
        {
            Salario = salario;
        }

        public void SetCargoId(int cargo)
        {
            CargoId = cargo;
        }

        public void SetFuncaoId(int funcao)
        {
            FuncaoId = funcao;
        }
    }
}
