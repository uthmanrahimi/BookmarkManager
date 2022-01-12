using BookmarkManager.Application.Dto;

using MediatR;

namespace BookmarkManager.Application.Features
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
