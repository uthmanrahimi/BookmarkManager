using System;

namespace BookmarkManager.Domain.Entities
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime Created { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
