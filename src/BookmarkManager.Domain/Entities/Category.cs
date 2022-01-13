using System.Collections.Generic;

namespace BookmarkManager.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<BookmarkCategory> Bookmarks { get; set; } = new List<BookmarkCategory>();
    }
}
