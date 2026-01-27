using TodoList.Core.Interfaces.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Database.Context;

namespace TodoList.Infrastructure.Repositories;

public class TodoRepository(TodoListContext context) : BaseRepository<Todo, Guid>(context), ITodoRepository
{

}
