using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    public class PlacePerkRequest
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public int PlaceId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int PerkId { get; set; }
    }
}
