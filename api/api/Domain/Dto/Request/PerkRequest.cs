using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    public class PerkRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O campo {0} deve ter no máximo 80 caracteres")]
        public string Name { get; set; }
    }
}
