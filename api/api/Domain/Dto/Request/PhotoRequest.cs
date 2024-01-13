using System.ComponentModel.DataAnnotations;

namespace api.Domain.Dto.Request
{
    public class PhotoRequest
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string Url { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public int PlaceId { get; set; }
    }
}
