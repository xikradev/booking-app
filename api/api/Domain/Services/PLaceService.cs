using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;

namespace api.Domain.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _repository;

        public PlaceService(IPlaceRepository repository)
        {
            _repository = repository;
        }

        public void Add(Place place)
        {
            _repository.Add(place);
        }

        public void Delete(Place place)
        {
            _repository.Delete(place);
        }

        public Place? Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Place> FindAll()
        {
            return _repository.FindAll();
        }

        public void Update(Place place)
        {
            _repository.Update(place);
        }
    }
}
