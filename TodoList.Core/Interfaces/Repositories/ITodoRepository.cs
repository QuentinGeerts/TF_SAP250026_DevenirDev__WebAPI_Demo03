using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Repositories;

public interface ITodoRepository : IBaseRepository<Todo, Guid>
{
}
