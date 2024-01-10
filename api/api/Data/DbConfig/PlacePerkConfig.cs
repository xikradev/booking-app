using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DbConfig
{
    public class PlacePerkConfig : IEntityTypeConfiguration<PlacePerk>
    {
        public void Configure(EntityTypeBuilder<PlacePerk> builder)
        {
            builder
                .HasKey(pp => new { pp.PerkId, pp.PlaceId });
            builder.HasOne(pp => pp.Place)
                .WithMany(p => p.PlacePerks)
                .HasForeignKey(pp => pp.PlaceId);
            builder
                .HasOne(pp => pp.Perk)
                .WithMany(p => p.PlacePerks)
                .HasForeignKey(pp => pp.PerkId);
        }
    }
}
