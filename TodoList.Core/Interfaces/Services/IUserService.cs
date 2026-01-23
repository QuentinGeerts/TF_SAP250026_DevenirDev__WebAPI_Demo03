using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services;

public interface IUserService : IBaseService<User, Guid>
{
}
