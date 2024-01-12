using api.Domain.Models;
using api.Domain.Viewer;

namespace api.Domain.Interfaces
{
    public interface IPlaceService
    {
        public IEnumerable<PlaceViewer> FindAll();
        public PlaceViewer? Find(int id);
        public void Add(Place place);
        public void Update(Place place);
        public void Delete(Place place);
    }
}
