﻿namespace Funcionarios.Domain.DTO
{
    public class FuncionarioCltDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Salario { get; set; }
        public int FuncaoId { get; set; }
        public int CargoId { get; set; }
    }
}
