namespace TodoList.Core.Interfaces.Services;

public interface IBaseService<TEntity, TKey>
    where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);

    Task<TEntity> CreateAsync(TEntity user);
    Task UpdateAsync(TKey id, TEntity user);
    Task DeleteAsync(TKey id);
}
