using api.Domain.Models;

namespace api.Domain.Interfaces
{
    public interface IAddressService
    {
        public IEnumerable<Address> FindAll();
        public Address? Find(int id);
        public void Add(Address address);
        public void Update(Address address);
        public void Delete(Address address);
    }
}
