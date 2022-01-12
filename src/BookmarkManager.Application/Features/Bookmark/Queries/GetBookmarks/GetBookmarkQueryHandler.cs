using AutoMapper;
using AutoMapper.QueryableExtensions;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarksQueryHanlder : IRequestHandler<GetBookmarksQuery, IEnumerable<BookmarkDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookmarksQueryHanlder(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookmarkDto>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookmarks.AsNoTrackingWithIdentityResolution()
                        .Include(b => b.Categories).ThenInclude(b => b.Category)
                        .AsNoTracking()
                        .Where(b => b.OwnerId == request.OwnerId)
                        .ProjectTo<BookmarkDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
