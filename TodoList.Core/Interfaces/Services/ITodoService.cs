using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services;

public interface ITodoService : IBaseService<Todo, Guid>
{

}
