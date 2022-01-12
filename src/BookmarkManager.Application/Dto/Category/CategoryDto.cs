using BookmarkManager.Application.Common;
using BookmarkManager.Domain.Entities;

namespace BookmarkManager.Application.Dto.Category
{
    public class CategoryDto: IMapFrom<BookmarkEntity>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
