
using MediatR;

namespace BookmarkManager.Application.Features
{
    public class DeleteBookmarkCommand : IRequest
    {
        public int Id { get; init; }
        public DeleteBookmarkCommand(int id)
        {
            Id = id;
        }
    }
}
