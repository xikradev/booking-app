namespace api.Domain.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int MaxGuest { get; set; }
        public int AddressId { get; set; }


        public virtual Address Address { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Perk> Perks { get; set; }


    }
}
