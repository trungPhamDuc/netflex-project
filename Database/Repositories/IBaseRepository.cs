using Netflex.Entities.Abstractions;

namespace Netflex.Database.Repositories;

public interface IBaseRepository<T> where T : class, IEntity
{
    IQueryable<T> Entities { get; }
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task SaveChangeAsync();
    
}