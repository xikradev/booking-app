namespace api.Domain.Dto.Request
{
    public class PlaceRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExtraInfo { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int MaxGuest { get; set; }
        public int AddressId { get; set; }
    }
}
