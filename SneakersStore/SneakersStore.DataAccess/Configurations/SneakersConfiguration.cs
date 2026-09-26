using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SneakersStore.Core.Models;
using SneakersStore.DataAccess.Entites;

namespace SneakersStore.DataAccess.Configurations
{
    public class SneakersConfiguration : IEntityTypeConfiguration<SneakersEntity>
    {
        public void Configure(EntityTypeBuilder<SneakersEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .HasMaxLength(Sneakers.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.Img)
                .IsRequired();
        }
    }
}
