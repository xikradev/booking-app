using api.Domain.Models;
using System.Text.Json.Serialization;

namespace api.Domain.Dto.Response
{
    public class PhotoResponse
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PlaceId { get; set; }
        [JsonIgnore]
        public virtual PlaceResponse Place { get; set; }
    }
}
