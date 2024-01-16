using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    public class PlacePerkRequest
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor de {0} deve ser maior que 0.")]
        public int PlaceId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor de {0} deve ser maior que 0.")]
        public int PerkId { get; set; }
    }
}
