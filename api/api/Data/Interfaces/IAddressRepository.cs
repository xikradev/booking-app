using api.Domain.Models;

namespace api.Data.Interfaces
{
    public interface IAddressRepository
    {
        public IEnumerable<Address> FindAll();
        public Address? Find(int id);
        public void Add(Address address);
        public void Update(Address address);
        public void Delete(Address address);
    }
}
