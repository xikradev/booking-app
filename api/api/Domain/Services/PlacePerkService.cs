using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.Viewer;

namespace api.Domain.Services
{
    public class PlacePerkService : IPlacePerkService
    {
        private readonly IPlacePerkRepository _repository;

        public PlacePerkService(IPlacePerkRepository repository)
        {
            _repository = repository;
        }

        public void Add(PlacePerk placePerk)
        {
            _repository.Add(placePerk);
        }

        public void Delete(PlacePerk placePerk)
        {
            _repository.Delete(placePerk);
        }

        public IEnumerable<PlacePerkViewer> FindAll()
        {
            return _repository.FindAll();
        }

        public IEnumerable<PlacePerkViewer> FindByPerk(int id)
        {
            return _repository.FindByPerk(id);
        }

        public IEnumerable<PlacePerkViewer> FindByPlace(int id)
        {
            return _repository.FindByPlace(id);
        }

        public PlacePerkViewer? FindByPlacePerk(int placeId, int perkId)
        {
            return _repository.FindByPlacePerk(placeId, perkId);
        }

        public void Update(PlacePerk placePerk)
        {
            _repository.Update(placePerk);
        }
    }
}
