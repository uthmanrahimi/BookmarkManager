using AutoMapper;

using BookmarkManager.Application.Common;
using BookmarkManager.Application.Dto.Category;
using BookmarkManager.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

namespace BookmarkManager.Application.Dto
{
    public class BookmarkDto : IMapFrom<BookmarkEntity>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookmarkEntity, BookmarkDto>()
                .ForMember(dest => dest.Categories, src => src.MapFrom(b => b.Categories.Select(x => new CategoryDto { Id = x.CategoryId, Title = x.Category.Title })));
        }

    }
}
