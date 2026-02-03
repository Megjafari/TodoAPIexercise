using Microsoft.AspNetCore.Mvc;
using TodoAPIexercise.Models;
using TodoAPIexercise.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return Ok(_itemsService.GetAll());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id)
        {
            var item = _itemsService.GetById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST (CREATE)
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem newItem)
        {
            var created = _itemsService.Create(newItem);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT (UPDATE)
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updatedItem)
        {
            var existingItem = _itemsService.GetById(id);

            if (existingItem == null)
                return NotFound();

            _itemsService.Update(id, updatedItem);

            return NoContent(); // 204 success
        }


        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _itemsService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
