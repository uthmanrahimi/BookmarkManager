using BookmarkManager.Application.Dto;

using MediatR;

namespace BookmarkManager.Application.Features
{
    public class GetCategoryQuery : IRequest<CategoryDto>
    {
        public int Id { get; init; }
        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
