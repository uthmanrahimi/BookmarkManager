using BookmarkManager.Application.Features;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace BookmarkManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _sender;

        public CategoryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var categories = await _sender.Send(new GetCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var category = await _sender.Send(new GetCategoryQuery(id));
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var category = await _sender.Send(command);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            if (id == 0)
                return BadRequest();
            return Ok(await _sender.Send(new DeleteCategoryCommand(id)));
        }

    }
}
