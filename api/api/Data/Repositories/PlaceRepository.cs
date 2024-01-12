using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Dto.Response;
using api.Domain.Models;
using api.Domain.Viewer;
using Microsoft.EntityFrameworkCore;

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

        public PlaceViewer? Find(int id)
        {
            var placeViewer = _context.Places
                .Include(place => place.Address)
                .Include(place => place.Photos)
                .Include(place => place.PlacePerks)
                    .ThenInclude(placePerk => placePerk.Perk)
                .Select(place => new PlaceViewer
                {
                    Id = place.Id,
                    Title = place.Title,
                    Description = place.Description,
                    ExtraInfo = place.ExtraInfo,
                    CheckIn = place.CheckIn,
                    CheckOut = place.CheckOut,
                    MaxGuest = place.MaxGuest,
                    AddressId = place.AddressId,
                    Address = new Address
                    {
                        Id = place.Address.Id,
                        Street = place.Address.Street,
                        City = place.Address.City,
                        State = place.Address.State,
                        ZipCode = place.Address.ZipCode
                    },
                    Photos = place.Photos.Select(photo => new Photo
                    {
                        Id = photo.Id,
                        Url = photo.Url
                    }).ToList(),
                    Perks = place.PlacePerks.Select(placePerk => new Perk
                    {
                        Id = placePerk.Perk.Id,
                        Name = placePerk.Perk.Name
                    }).ToList()
                }).FirstOrDefault(x => x.Id == id);

            return placeViewer;

        }

        public IEnumerable<PlaceViewer> FindAll()
        {
            var placeViewer = _context.Places
                .Include(place => place.Address)
                .Include(place => place.Photos)
                .Include(place => place.PlacePerks)
                    .ThenInclude(placePerk => placePerk.Perk)
                .Select(place => new PlaceViewer
                {
                    Id = place.Id,
                    Title = place.Title,
                    Description = place.Description,
                    ExtraInfo = place.ExtraInfo,
                    CheckIn = place.CheckIn,
                    CheckOut = place.CheckOut,
                    MaxGuest = place.MaxGuest,
                    AddressId = place.AddressId,
                    Address = new Address
                    {
                        Id = place.Address.Id,
                        Street = place.Address.Street,
                        City = place.Address.City,
                        State = place.Address.State,
                        ZipCode = place.Address.ZipCode
                    },
                    Photos = place.Photos.Select(photo => new Photo
                    {
                        Id = photo.Id,
                        Url = photo.Url
                    }).ToList(),
                    Perks = place.PlacePerks.Select(placePerk => new Perk
                    {
                        Id = placePerk.Perk.Id,
                        Name = placePerk.Perk.Name
                    }).ToList()
                })
                .ToList();

            return placeViewer;
        }

        public void Update(Place place)
        {
            _context.Places.Update(place);
            _context.SaveChanges();
        }
    }
}
