using BookmarkManager.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BookmarkEntity> Bookmarks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
