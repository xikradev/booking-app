using api.Data.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;

namespace api.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public void Add(Address address)
        {
            _repository.Add(address);
        }

        public void Delete(Address address)
        {
            _repository.Delete(address);
        }

        public Address? Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<Address> FindAll()
        {
            return _repository.FindAll();
        }

        public void Update(Address address)
        {
            _repository.Update(address);
        }
    }
}
