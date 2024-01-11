using api.Domain.Models;

namespace api.Domain.Dto.Response
{
    public class PlacePerkResponse
    {
        public int PlaceId { get; set; }
        public virtual PlaceResponse Place { get; set; }

        public int PerkId { get; set; }
        public virtual PerkResponse Perk { get; set; }
    }
}
