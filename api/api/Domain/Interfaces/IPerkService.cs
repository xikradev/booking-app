using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IPerkService
    {
        public IEnumerable<Perk> FindAll();
        public Perk? Find(int id);
        public void Add(Perk perk);
        public void Update(Perk perk);
        public void Delete(Perk perk);
    }
}
