using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _context;

        public PhotoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void Delete(Photo photo)
        {
            _context.Photos.Remove(photo);
            _context.SaveChanges();
        }

        public Photo? Find(int id)
        {
            return _context.Photos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Photo> FindAll()
        {
            return _context.Photos.ToList();
        }

        public void Update(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
