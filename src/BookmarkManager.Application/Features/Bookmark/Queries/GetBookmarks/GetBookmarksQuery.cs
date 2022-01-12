using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarksQuery : IRequest<IEnumerable<BookmarkDto>>
    {
        public int OwnerId { get; init; }
        public GetBookmarksQuery(int ownerid)
        {
            OwnerId = ownerid;
        }
    }
}
