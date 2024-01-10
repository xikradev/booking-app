using api.Domain.Models;

namespace api.Domain.Dto.Response
{
    public class PhotoResponse
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PlaceId { get; set; }
        public virtual PlaceResponse Place { get; set; }
    }
}
