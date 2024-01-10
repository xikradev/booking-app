using api.Data.Context;
using api.Data.Interfaces;
using api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Delete(Address address)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }

        public Address? Find(int id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Address> FindAll()
        {
            return _context.Addresses.ToList();
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
