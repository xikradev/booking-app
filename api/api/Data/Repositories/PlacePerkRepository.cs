using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Repositories
{
    public class PlacePerkRepository : IPlacePerkRepository
    {
        private readonly AppDbContext _context;

        public PlacePerkRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(PlacePerk placePerk)
        {
            _context.Add(placePerk);
            _context.SaveChanges();
        }

        public void Delete(PlacePerk placePerk)
        {
            _context.Remove(placePerk);
            _context.SaveChanges();
        }

        public PlacePerk? FindByPerk(int id)
        {
            return _context.PlacePerks.FirstOrDefault(x => x.PerkId == id);
        }

        public PlacePerk? FindByPlace(int id)
        {
            return _context.PlacePerks.FirstOrDefault(x => x.PlaceId == id);
        }

        public IEnumerable<PlacePerk> FindAll()
        {
            return _context.PlacePerks.ToList();
        }

        public void Update(PlacePerk placePerk)
        {
            _context.Entry(placePerk).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
