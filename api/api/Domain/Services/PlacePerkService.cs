using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;

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

        public IEnumerable<PlacePerk> FindAll()
        {
            return _repository.FindAll();
        }

        public PlacePerk? FindByPerk(int id)
        {
            return _repository.FindByPerk(id);
        }

        public PlacePerk? FindByPlace(int id)
        {
            return _repository.FindByPlace(id);
        }

        public void Update(PlacePerk placePerk)
        {
            _repository.Update(placePerk);
        }
    }
}
