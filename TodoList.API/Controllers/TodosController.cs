using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController(ITodoService _todoService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _todoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo([FromRoute] Guid id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(Guid id, Todo todo)
        {
            // TODO
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            // TODO
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            try
            {
                await _todoService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
