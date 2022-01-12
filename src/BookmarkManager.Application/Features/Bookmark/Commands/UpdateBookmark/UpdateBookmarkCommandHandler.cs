using AutoMapper;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;
using BookmarkManager.Domain.Entities;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class UpdateBookmarkCommandHandler : IRequestHandler<UpdateBookmarkCommand, BookmarkDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateBookmarkCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookmarkDto> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var bookmark = await _dbContext.Bookmarks.SingleOrDefaultAsync(b => b.Id == request.Id);
            if (bookmark == null)
                throw new NullReferenceException($"Bookmark with given ID ({request.Id}) does not exist.");// TODO: create custome exception class 

            bookmark = _mapper.Map<BookmarkEntity>(request);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookmarkDto>(bookmark);
        }
    }
}
