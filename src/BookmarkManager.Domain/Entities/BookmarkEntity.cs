
using System;
using System.Collections.Generic;

namespace BookmarkManager.Domain.Entities
{
    public class BookmarkEntity: BaseEntity
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<BookmarkCategoryEntity> Categories { get; set; }
    }
}
