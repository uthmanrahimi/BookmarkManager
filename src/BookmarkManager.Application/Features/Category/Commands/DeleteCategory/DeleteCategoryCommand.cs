
using MediatR;

namespace BookmarkManager.Application.Features
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; init; }
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
