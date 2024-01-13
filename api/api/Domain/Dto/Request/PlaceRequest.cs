using api.Domain.Annotations;
using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    [CheckinCheckoutValidation]
    public class PlaceRequest
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [MaxLength(150, ErrorMessage ="O campo {0} deve ter no máximo {1}")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(300, ErrorMessage = "O campo {0} deve ter no máximo {1}")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1}")]
        public string ExtraInfo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime CheckIn { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime CheckOut { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1,10, ErrorMessage ="O valor do campo {0} deve ser entre 1 e 10")]
        public int MaxGuest { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int AddressId { get; set; }
    }
}
