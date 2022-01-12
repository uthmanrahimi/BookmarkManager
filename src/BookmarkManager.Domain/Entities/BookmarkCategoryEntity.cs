namespace BookmarkManager.Domain.Entities
{
    public class BookmarkCategoryEntity
    {
        public BookmarkEntity Bookmark { get; set; }
        public int BookmarkId { get; set; }
        public CategoryEntity Category { get; set; }
        public int CategoryId { get; set; }
    }
}
