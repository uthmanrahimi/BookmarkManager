
using BookmarkManager.Application.Common.Exceptions;
using BookmarkManager.Application.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCategoryCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == request.Id);
            if (category == null)
                throw new RestException(HttpStatusCode.NotFound,$"Category with given ID ({request.Id}) does not exist.");// TODO: create custome exception class 

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
