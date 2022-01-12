using AutoMapper;

using BookmarkManager.Application.Common.Exceptions;
using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarkQueryHanlder : IRequestHandler<GetBookmarkQuery, BookmarkDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookmarkQueryHanlder(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BookmarkDto> Handle(GetBookmarkQuery request, CancellationToken cancellationToken)
        {
            var bookmark = await _dbContext.Bookmarks.AsNoTrackingWithIdentityResolution()
                                .Include(b => b.Categories).ThenInclude(b => b.Category)
                                .SingleOrDefaultAsync(b => b.Id == request.Id);
            if (bookmark == null)
                throw new RestException(HttpStatusCode.NotFound, $"Bookmark with given ID ({request.Id}) does not exist.");

            return _mapper.Map<BookmarkDto>(bookmark);
        }
    }
}
