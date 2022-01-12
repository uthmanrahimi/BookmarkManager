using BookmarkManager.Application.Common;
using BookmarkManager.Domain.Entities;

namespace BookmarkManager.Application.Dto
{
    public class CategoryDto: IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
