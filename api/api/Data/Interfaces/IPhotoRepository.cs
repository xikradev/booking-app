using api.Domain.Models;

namespace api.Data.Interfaces
{
    public interface IPhotoRepository
    {
        public IEnumerable<Photo> FindAll();
        public Photo? Find(int id);
        public void Add(Photo photo);
        public void Update(Photo photo);
        public void Delete(Photo photo);
    }
}
