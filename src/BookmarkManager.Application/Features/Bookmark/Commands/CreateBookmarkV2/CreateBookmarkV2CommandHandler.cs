using AutoMapper;

using BookmarkManager.Application.Dto;
using BookmarkManager.Application.Interfaces;
using BookmarkManager.Domain.Entities;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookmarkManager.Application.Features
{
    public class CreateBookmarkV2CommandHandler : IRequestHandler<CreateBookmarkV2Command, BookmarkDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookmarkV2CommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BookmarkDto> Handle(CreateBookmarkV2Command request, CancellationToken cancellationToken)
        {
            var bookmark = _mapper.Map<Bookmark>(request);
            await AddCategories(bookmark, request);
            await _dbContext.Bookmarks.AddAsync(bookmark, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BookmarkDto>(bookmark);
        }

        private async Task AddCategories(Bookmark bookmark, CreateBookmarkV2Command command)
        {
            var categories = command.Categories;
            var existedCategories = await _dbContext.Categories.Where(c => categories.Contains(c.Title)).ToListAsync();
            var newCategories = categories.Except(existedCategories.Select(r => r.Title));

            foreach (var category in existedCategories)
                bookmark.Categories.Add(new BookmarkCategory { CategoryId = category.Id });

            foreach (var item in newCategories)
            {
                var category = new Category { Title = item };
                bookmark.Categories.Add(new BookmarkCategory { Category = category });
            }

        }
    }
}
