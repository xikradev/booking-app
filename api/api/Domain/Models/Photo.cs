namespace api.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}
