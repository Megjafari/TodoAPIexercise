using Microsoft.AspNetCore.Mvc;
using TodoAPIexercise.Data;
using TodoAPIexercise.Models;
using TodoAPIexercise.Services;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAll()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST (CREATE)
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem newItem)
        {
            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        // PUT (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem updatedItem)
        {
            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null) return NotFound();

            // Uppdatera fälten
            existingItem.Title = updatedItem.Title;
            existingItem.IsCompleted = updatedItem.IsCompleted;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 success
        }


        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
