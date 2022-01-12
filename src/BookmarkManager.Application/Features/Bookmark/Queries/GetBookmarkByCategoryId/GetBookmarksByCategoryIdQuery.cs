using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarksByCategoryIdQuery : IRequest<IEnumerable<BookmarkDto>>
    {
        public int CategoryId { get; init; }
        public GetBookmarksByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
