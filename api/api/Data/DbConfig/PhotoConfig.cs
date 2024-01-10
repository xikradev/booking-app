using api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.DbConfig
{
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Url)
                .IsRequired();
        }
    }
}
