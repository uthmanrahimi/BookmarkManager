using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarkByCategoryIdQuery : IRequest<IEnumerable<BookmarkDto>>
    {
        public int CategoryId { get; init; }
        public GetBookmarkByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
