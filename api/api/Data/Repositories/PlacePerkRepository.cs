using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;
using api.Domain.Viewer;
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

        public IEnumerable<PlacePerkViewer> FindByPerk(int id)
        {
            return _context.PlacePerks
                .Include(placePerk => placePerk.Place)
                .Include(placePerk => placePerk.Perk)
                .Select(placePerk => new PlacePerkViewer
                {
                    PlaceId = placePerk.PlaceId,
                    Title = placePerk.Place.Title,
                    Description = placePerk.Place.Description,
                    PerkId = placePerk.PerkId,
                    Perk = new Perk
                    {
                        Id = placePerk.PerkId,
                        Name = placePerk.Perk.Name
                    }
                }).Where(x => x.PerkId == id);
        }

        public IEnumerable<PlacePerkViewer> FindByPlace(int id)
        {
            return _context.PlacePerks
                .Include(placePerk => placePerk.Place)
                .Include(placePerk => placePerk.Perk)
                .Select(placePerk => new PlacePerkViewer
                {
                    PlaceId = placePerk.PlaceId,
                    Title = placePerk.Place.Title,
                    Description = placePerk.Place.Description,
                    PerkId = placePerk.PerkId,
                    Perk = new Perk
                    {
                        Id = placePerk.PerkId,
                        Name = placePerk.Perk.Name
                    }
                }).Where(x => x.PlaceId == id); ;
        }

        public IEnumerable<PlacePerkViewer> FindAll()
        {
            var placePerkLst =  _context.PlacePerks
                .Include(placePerk => placePerk.Place)
                .Include(placePerk => placePerk.Perk)
                .Select(placePerk => new PlacePerkViewer
                {
                    PlaceId = placePerk.PlaceId,
                    Title = placePerk.Place.Title,
                    Description = placePerk.Place.Description,
                    PerkId = placePerk.PerkId,
                    Perk = new Perk
                    {
                        Id = placePerk.PerkId,
                        Name = placePerk.Perk.Name
                    }
                }).ToList();

            return placePerkLst;
        }

        public void Update(PlacePerk placePerk)
        {
            _context.Entry(placePerk).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public PlacePerkViewer? FindByPlacePerk(int placeId, int perkId)
        {
            return _context.PlacePerks
                .Include(placePerk => placePerk.Place)
                .Include(placePerk => placePerk.Perk)
                .Select(placePerk => new PlacePerkViewer
                {
                    PlaceId = placePerk.PlaceId,
                    Title = placePerk.Place.Title,
                    Description = placePerk.Place.Description,
                    PerkId = placePerk.PerkId,
                    Perk = new Perk
                    {
                        Id = placePerk.PerkId,
                        Name = placePerk.Perk.Name
                    }
                }).FirstOrDefault(x => x.PerkId == perkId && x.PlaceId == placeId);
        }
    }
}
