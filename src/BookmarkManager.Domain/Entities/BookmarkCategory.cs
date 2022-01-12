namespace BookmarkManager.Domain.Entities
{
    public class BookmarkCategory
    {
        public Bookmark Bookmark { get; set; }
        public int BookmarkId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
