using BookmarkManager.Application.Dto;

using MediatR;

namespace BookmarkManager.Application.Features
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Title { get; set; }
    }
}
