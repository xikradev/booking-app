using api.Domain.Models;
using api.Domain.Viewer;

namespace api.Data.Interfaces
{
    public interface IPlaceRepository
    {
        public IEnumerable<PlaceViewer> FindAll();
        public PlaceViewer Find(int id);
        public void Add(Place place);
        public void Update(Place place);
        public void Delete(Place place);
    }
}
