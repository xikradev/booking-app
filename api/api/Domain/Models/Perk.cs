namespace api.Domain.Models
{
    public class Perk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PlacePerk> PlacePerks { get; set; }
    }
}
