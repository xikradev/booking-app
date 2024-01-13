using api.Domain.Models;

namespace api.Domain.Dto.Response
{
    public class PlacePerkResponse
    {
        public int PlaceId { get; set; }
        public PlaceResponse Place { get; set; }

        public int PerkId { get; set; }
        public PerkResponse Perk { get; set; }
    }
}
