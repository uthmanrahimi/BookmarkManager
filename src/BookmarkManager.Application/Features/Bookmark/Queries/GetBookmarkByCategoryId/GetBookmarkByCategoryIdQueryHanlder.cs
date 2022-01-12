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
    public class GetBookmarkByCategoryIdQueryHanlder : IRequestHandler<GetBookmarkByCategoryIdQuery, IEnumerable<BookmarkDto>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookmarkByCategoryIdQueryHanlder(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookmarkDto>> Handle(GetBookmarkByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookmarks.Include(b => b.Categories)
                                .Include(b => b.Categories).ThenInclude(x => x.Category)
                                .Where(b => b.Categories.Any(c => c.CategoryId == request.CategoryId))
                                .ProjectTo<BookmarkDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
