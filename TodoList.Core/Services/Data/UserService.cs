using TodoList.Core.Interfaces.Repositories;
using TodoList.Core.Interfaces.Services;
using TodoList.Domain.Entities;

namespace TodoList.Core.Services.Data;

public class UserService(IUserRepository _userRespository) : IUserService
{
    public async Task Delete(Guid id)
    {
        var user = await _userRespository.GetById(id);

        if (user == null) throw new KeyNotFoundException("Id not found");

        await _userRespository.Delete(user.Id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userRespository.GetAll();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _userRespository.GetById(id);
    }
}
