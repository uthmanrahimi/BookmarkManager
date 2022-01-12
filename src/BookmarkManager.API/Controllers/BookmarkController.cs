using BookmarkManager.Application.Features;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace BookmarkManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly ISender _sender;

        public BookmarkController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("owner/{ownerId}/all")]
        public async Task<IActionResult> GetBookmarksByOwnerId(int ownerId)
        {
            var bookmarks = await _sender.Send(new GetBookmarksQuery(ownerId));
            return Ok(bookmarks);
        }

        [HttpGet("category/{categoryId}/all")]
        public async Task<IActionResult> GetBookmarksByCategoryId(int categoryId)
        {
            var bookmarks = await _sender.Send(new GetBookmarksByCategoryIdQuery(categoryId));
            return Ok(bookmarks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var bookmark = await _sender.Send(new GetBookmarkQuery(id));
            return Ok(bookmark);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBookmark([FromBody] CreateBookmarkCommand command)
        {
            var bookmark = await _sender.Send(command);
            return CreatedAtAction(nameof(Get), new { id = bookmark.Id }, bookmark);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookmark([FromBody] UpdateBookmarkCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookmarkById(int id)
        {
            return Ok(await _sender.Send(new DeleteBookmarkCommand(id)));
        }

    }
}
