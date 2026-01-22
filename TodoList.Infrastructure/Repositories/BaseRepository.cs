using Microsoft.EntityFrameworkCore;
using TodoList.Core.Interfaces.Repositories;
using TodoList.Infrastructure.Database;

namespace TodoList.Infrastructure.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{

    protected TodoListContext _context;
    protected DbSet<TEntity> _entities;

    public BaseRepository(TodoListContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async Task<TEntity> Create(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(TKey id)
    {
        var entity = await _entities.FindAsync(id);
        if (entity != null)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity?> GetById(TKey id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task Update(TKey id, TEntity entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }
}
