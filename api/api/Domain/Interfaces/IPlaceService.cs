using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IPlaceService
    {
        public IEnumerable<Place> FindAll();
        public Place? Find(int id);
        public void Add(Place place);
        public void Update(Place place);
        public void Delete(Place place);
    }
}
