using AutoMapper;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;
using BookmarkManager.Domain.Entities;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, BookmarkDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookmarkCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookmarkDto> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var bookmark = _mapper.Map<BookmarkEntity>(request);
            await _dbContext.Bookmarks.AddAsync(bookmark, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BookmarkDto>(bookmark);
        }
    }
}
