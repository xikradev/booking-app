using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;

namespace api.Domain.Services
{
    public class PerkService : IPerkService
    {
        private readonly IPerkRepository _repository;

        public PerkService(IPerkRepository repository)
        {
            _repository = repository;
        }

        public void Add(Perk perk)
        {
            _repository.Add(perk);
        }

        public void Delete(Perk perk)
        {
            _repository.Delete(perk);
        }

        public Perk? Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Perk> FindAll()
        {
            return _repository.FindAll();
        }

        public void Update(Perk perk)
        {
            _repository.Update(perk);
        }
    }
}
