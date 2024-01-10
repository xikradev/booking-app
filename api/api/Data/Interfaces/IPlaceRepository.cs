using api.Domain.Models;

namespace api.Data.Interfaces
{
    public interface IPlaceRepository
    {
        public IEnumerable<Place> FindAll();
        public Place Find(int id);
        public void Add(Place place);
        public void Update(Place place);
        public void Delete(Place place);
    }
}
