using api.Domain.Models;

namespace api.Domain.Dto.Response
{
    public class PerkResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlacePerkResponse> PlacePerks { get; set; }
    }
}
