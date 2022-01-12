using BookmarkManager.Application.Dto;

using MediatR;

using System.Collections.Generic;

namespace BookmarkManager.Application.Features
{
    public class CreateBookmarkV2Command : IRequest<BookmarkDto>
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public int OwnerId { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
