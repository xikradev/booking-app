using api.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    public class AddressRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(120)]
        public string Street { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(80)]
        public string City { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Formato de CEP inválido. Use o formato 12345-678.")]
        public string ZipCode { get; set; }
    }
}
