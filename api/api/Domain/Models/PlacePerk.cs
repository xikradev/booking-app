namespace api.Domain.Models
{
    public class PlacePerk
    {
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

        public int PerkId { get; set; }
        public virtual Perk Perk { get; set; }
    }
}
