using Microsoft.EntityFrameworkCore;
using TodoList.Core.Interfaces.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Database;

namespace TodoList.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    public UserRepository(TodoListContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _entities.FirstOrDefaultAsync(e => e.Email == email);
    }
}
