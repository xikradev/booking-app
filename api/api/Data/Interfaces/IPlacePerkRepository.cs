using api.Domain.Models;

namespace api.Data.Interfaces
{
    public interface IPlacePerkRepository
    {
        public IEnumerable<PlacePerk> FindAll();
        public PlacePerk? FindByPerk(int id);
        public PlacePerk? FindByPlace(int id);
        public void Add(PlacePerk placePerk);
        public void Update(PlacePerk placePerk);
        public void Delete(PlacePerk placePerk);
    }
}
