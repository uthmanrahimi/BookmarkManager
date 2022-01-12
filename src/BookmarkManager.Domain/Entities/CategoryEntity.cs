using System.Collections.Generic;

namespace BookmarkManager.Domain.Entities
{
    public class CategoryEntity:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<BookmarkCategoryEntity> Bookmarks { get; set; }
    }
}
