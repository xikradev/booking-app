using api.Domain.Dto.Response;
using api.Domain.Models;

namespace api.Domain.Viewer
{
    public class PlacePerkViewer
    {
        public int PlaceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PerkId { get; set; }
        public Perk Perk { get; set; }
    }
}
