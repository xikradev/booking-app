using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DbConfig
{
    public class PerkConfig : IEntityTypeConfiguration<Perk>
    {
        public void Configure(EntityTypeBuilder<Perk> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired().HasMaxLength(80);
        }
    }
}
