using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;

namespace api.Data.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly AppDbContext _context;

        public PlaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Place place)
        {
            _context.Places.Add(place);
            _context.SaveChanges();
        }

        public void Delete(Place place)
        {
            _context.Places.Remove(place);
            _context.SaveChanges();
        }

        public Place? Find(int id)
        {
            return _context.Places.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Place> FindAll()
        {
            return _context.Places.ToList();
        }

        public void Update(Place place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }
    }
}
