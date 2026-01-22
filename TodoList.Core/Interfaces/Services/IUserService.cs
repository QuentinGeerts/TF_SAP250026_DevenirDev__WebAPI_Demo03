using TodoList.Core.Interfaces.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Services;

public interface IUserService
{
    Task Delete(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User?> GetById(Guid id);
}
