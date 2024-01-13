using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IPlacePerkService
    {
        public IEnumerable<PlacePerk> FindAll();
        public PlacePerk? FindByPerk(int id);
        public PlacePerk? FindByPlace(int id);
        public void Add(PlacePerk placePerk);
        public void Update(PlacePerk placePerk);
        public void Delete(PlacePerk placePerk);
    }
}
