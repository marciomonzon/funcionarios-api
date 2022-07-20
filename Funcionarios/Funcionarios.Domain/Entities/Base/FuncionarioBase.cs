namespace Funcionarios.Domain.Entities.Base
{
    public abstract class FuncionarioBase : EntityBase
    {
        public FuncionarioBase(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
    }
}
