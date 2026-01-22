namespace TodoList.Core.Interfaces.Repositories;

public interface IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    // Create | Read (All, ById) | Update | Delete
    Task<TEntity> Create(TEntity entity);
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetById(TKey id);
    Task Update(TKey id, TEntity entity);
    Task Delete(TKey id);
}
