using System.ComponentModel.DataAnnotations;

namespace Funcionarios.Domain.DTO
{
    public class CargoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(ErrorMessage = "Máximo 50 caracteres")]
        public string CBO { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(ErrorMessage = "Máximo 50 caracteres")]
        public string Nome { get; set; }
    }
}
