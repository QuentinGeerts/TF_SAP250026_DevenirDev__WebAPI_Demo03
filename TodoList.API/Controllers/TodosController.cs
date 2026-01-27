using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(ITodoService _todoService) : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Todo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Todo>> GetTodo([FromRoute] Guid id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutTodo([FromRoute] Guid id, [FromBody] Todo todo)
    {
        // TODO
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(typeof(Todo), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Todo>> PostTodo([FromBody] Todo todo)
    {
        // TODO
        return Created();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    }
}
