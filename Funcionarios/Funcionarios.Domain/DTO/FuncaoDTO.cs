namespace Funcionarios.Domain.DTO
{
    public class FuncaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}
