using TodoList.Core.Interfaces.Repositories;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

namespace TodoList.Core.Services.Data;

public class TodoService(ITodoRepository _todoRepository) : ITodoService
{
    public async Task<Todo> CreateAsync(Todo todo)
    {
        return await _todoRepository.AddAsync(todo);
    }

    public async Task DeleteAsync(Guid id)
    {
        var todoExisting = await _todoRepository.ExistsAsync(id);
        if (!todoExisting) throw new KeyNotFoundException("Id not found");
        await _todoRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        return await _todoRepository.GetAllAsync();
    }

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        return await _todoRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Guid id, Todo user)
    {
        // TODO
        throw new NotImplementedException();
    }
}
