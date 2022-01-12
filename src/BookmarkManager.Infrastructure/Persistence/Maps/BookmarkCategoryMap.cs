using BookmarkManager.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookmarkManager.Infrastructure.Persistence.Maps
{
    public class BookmarkCategoryMap: IEntityTypeConfiguration<BookmarkCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<BookmarkCategoryEntity> builder)
        {
            builder.ToTable("BookmarkCategories");
            builder.HasKey(e => new { e.BookmarkId, e.CategoryId });
            builder.HasOne(e => e.Bookmark).WithMany(e => e.Categories).HasForeignKey(c => c.BookmarkId);
            builder.HasOne(e => e.Category).WithMany(e => e.Bookmarks).HasForeignKey(c => c.CategoryId);
        }
    }
}
