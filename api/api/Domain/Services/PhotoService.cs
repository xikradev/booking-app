using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;

namespace api.Domain.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _repository;

        public PhotoService(IPhotoRepository repository)
        {
            _repository = repository;
        }

        public void Add(Photo photo)
        {
            _repository.Add(photo);
        }

        public void Delete(Photo photo)
        {
            _repository.Delete(photo);
        }

        public Photo? Find(int id)
        {
           return _repository.Find(id);
        }

        public IEnumerable<Photo> FindAll()
        {
            return _repository.FindAll();
        }

        public void Update(Photo photo)
        {
            _repository.Update(photo);
        }
    }
}
