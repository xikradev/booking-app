using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Repositories
{
    public class PerkRepository : IPerkRepository
    {
        private readonly AppDbContext _context;

        public PerkRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Perk perk)
        {
            _context.Perks.Add(perk);
            _context.SaveChanges();
        }

        public void Delete(Perk perk)
        {
            _context.Perks.Remove(perk);
            _context.SaveChanges();
        }

        public Perk? Find(int id)
        {
            return _context.Perks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Perk> FindAll()
        {
            return _context.Perks.ToList();
        }

        public void Update(Perk perk)
        {
            _context.Entry(perk).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
