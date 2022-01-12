using BookmarkManager.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Bookmark> Bookmarks { get; set; }
        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
