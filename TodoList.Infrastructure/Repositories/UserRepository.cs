using Microsoft.EntityFrameworkCore;
using TodoList.Core.Interfaces.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Database.Context;

namespace TodoList.Infrastructure.Repositories;

public class UserRepository(TodoListContext context) : BaseRepository<User, Guid>(context), IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _entities.FirstOrDefaultAsync(e => e.Email == email);
    }
}
