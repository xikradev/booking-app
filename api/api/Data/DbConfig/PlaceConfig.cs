using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DbConfig
{
    public class PlaceConfig : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.ExtraInfo)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.CheckIn)
                .IsRequired()
                .HasColumnType("Date");
            builder.Property(x => x.CheckOut)
                .IsRequired()
                .HasColumnType("Date");
            builder.Property(x => x.MaxGuest)
                .IsRequired()
                .HasAnnotation("MaxLength", 3);

            builder.HasOne(p => p.Address)
                .WithOne(a => a.Place)
                .HasForeignKey<Place>(p => p.AddressId);

            builder.HasMany(p => p.Photos)
                .WithOne(ph => ph.Place)
                .HasForeignKey(ph => ph.PlaceId);

            builder.HasMany(p => p.Perks)
                .WithMany(perk => perk.Places)
                .UsingEntity(j => j.ToTable("PlacePerk"));
        }
    }
}
