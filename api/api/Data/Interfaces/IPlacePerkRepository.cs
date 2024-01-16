using api.Domain.Models;
using api.Domain.Viewer;

namespace api.Data.Interfaces
{
    public interface IPlacePerkRepository
    {
        public IEnumerable<PlacePerkViewer> FindAll();
        public IEnumerable<PlacePerkViewer> FindByPerk(int id);
        public IEnumerable<PlacePerkViewer> FindByPlace(int id);
        public PlacePerkViewer? FindByPlacePerk(int placeId, int perkId);
        public void Add(PlacePerk placePerk);
        public void Update(PlacePerk placePerk);
        public void Delete(PlacePerk placePerk);
    }
}
