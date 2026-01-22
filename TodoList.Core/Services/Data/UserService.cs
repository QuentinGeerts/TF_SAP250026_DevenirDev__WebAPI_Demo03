using TodoList.Core.Interfaces.Repositories;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

namespace TodoList.Core.Services.Data;

public class UserService(IUserRepository _userRespository) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        // TODO
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        var existingUser = await _userRespository.ExistsAsync(id);
        if (!existingUser) throw new KeyNotFoundException("Id not found");
        await _userRespository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRespository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRespository.GetByIdAsync(id);
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, User user)
    {
        // TODO
        throw new NotImplementedException();
    }
}
