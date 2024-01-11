using api.Data.DbConfig;
using api.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace api.Data.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlacePerk> PlacePerks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PlaceConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new  PhotoConfig());
            modelBuilder.ApplyConfiguration(new PerkConfig());
            modelBuilder.ApplyConfiguration(new PlacePerkConfig());
        }
    }
}
