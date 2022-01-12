using BookmarkManager.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookmarkManager.Infrastructure.Persistence.Maps
{
    public class BookmarkMap : IEntityTypeConfiguration<BookmarkEntity>
    {
        public void Configure(EntityTypeBuilder<BookmarkEntity> builder)
        {
            builder.ToTable("Bookmarks");
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.CreatedAt).IsRequired();
            //builder.HasQueryFilter(x => !x.IsDeleted); for applying global filter
        }
    }
}
