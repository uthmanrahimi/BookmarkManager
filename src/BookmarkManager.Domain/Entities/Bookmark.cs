
using System;
using System.Collections.Generic;

namespace BookmarkManager.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<BookmarkCategory> Categories { get; set; } = new List<BookmarkCategory>();
    }
}
