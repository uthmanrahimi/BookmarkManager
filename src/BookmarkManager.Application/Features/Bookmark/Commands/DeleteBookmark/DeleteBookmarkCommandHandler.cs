
using BookmarkManager.Application.Common.Exceptions;
using BookmarkManager.Application.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class DeleteBookmarkCommandHandler : IRequestHandler<DeleteBookmarkCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteBookmarkCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteBookmarkCommand request, CancellationToken cancellationToken)
        {
            var bookmark = await _dbContext.Bookmarks.SingleOrDefaultAsync(b => b.Id == request.Id);
            if (bookmark == null)
                throw new RestException(HttpStatusCode.NotFound,$"Bookmark with given ID ({request.Id}) does not exist.");// TODO: create custome exception class 

            _dbContext.Bookmarks.Remove(bookmark);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
