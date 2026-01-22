using TodoList.Domain.Entities;

namespace TodoList.Core.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    Task<User?> GetUserByEmail(string email);
}
