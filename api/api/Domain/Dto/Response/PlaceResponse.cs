using api.Domain.Models;

namespace api.Domain.Dto.Response
{
    public class PlaceResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int MaxGuest { get; set; }
        public int AddressId { get; set; }

        public virtual AddressResponse Address { get; set; }
        public virtual ICollection<PhotoResponse> Photos { get; set; }
        public virtual ICollection<PlacePerkResponse> PlacePerks { get; set; }
    }
}
