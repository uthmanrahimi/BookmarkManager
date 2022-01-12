using BookmarkManager.Application.Dto;

using MediatR;

namespace BookmarkManager.Application.Features
{
    public class GetBookmarkQuery : IRequest<BookmarkDto>
    {
        public int Id { get; init; }
        public GetBookmarkQuery(int id)
        {
            Id = id;
        }
    }
}
