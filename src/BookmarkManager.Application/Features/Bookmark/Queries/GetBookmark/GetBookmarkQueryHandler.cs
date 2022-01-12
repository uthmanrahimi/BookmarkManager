using AutoMapper;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;

using MediatR;

using System;
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
            var bookmark = await _dbContext.Bookmarks.FindAsync(request.Id);
            if (bookmark == null)
                throw new NullReferenceException($"Bookmark with given ID ({request.Id}) does not exist.");// TODO: create custome exception class 

            return _mapper.Map<BookmarkDto>(bookmark);
        }
    }
}
