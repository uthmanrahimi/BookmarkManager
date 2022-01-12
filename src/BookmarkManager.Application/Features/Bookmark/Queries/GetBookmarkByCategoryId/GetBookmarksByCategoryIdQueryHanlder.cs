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
    public class GetBookmarksByCategoryIdQueryHanlder : IRequestHandler<GetBookmarksByCategoryIdQuery, IEnumerable<BookmarkDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookmarksByCategoryIdQueryHanlder(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookmarkDto>> Handle(GetBookmarksByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookmarks.Include(b => b.Categories).AsNoTrackingWithIdentityResolution()
                                .Include(b => b.Categories).ThenInclude(x => x.Category)
                                .AsNoTracking()
                                .Where(b => b.Categories.Any(c => c.CategoryId == request.CategoryId))
                                .ProjectTo<BookmarkDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
