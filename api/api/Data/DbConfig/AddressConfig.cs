using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DbConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Street)
                .IsRequired().HasMaxLength(120);
            builder.Property(x => x.City)
                .IsRequired().HasMaxLength(80);
            builder.Property(x => x.State)
                .HasColumnType("CHAR(2)").IsRequired();
            builder.Property(x => x.ZipCode)
                .IsRequired().HasMaxLength(9);
        }
    }
}
