using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class UpdateBookmarkCommand : IRequest<BookmarkDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public List<int> Categories { get; set; } = new List<int>();
    }
}
