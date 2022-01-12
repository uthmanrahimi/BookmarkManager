
using MediatR;

namespace BookmarkManager.Application.Features
{
    public class DeleteBookmarkCommand : IRequest
    {
        public int Id { get; set; }
    }
}
