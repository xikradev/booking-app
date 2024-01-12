using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IPhotoService
    {
        public IEnumerable<Photo> FindAll();
        public Photo? Find(int id);
        public void Add(Photo photo);
        public void Update(Photo photo);
        public void Delete(Photo photo);
    }
}
