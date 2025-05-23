using Microsoft.EntityFrameworkCore;
using Netflex.Entities.Abstractions;

namespace Netflex.Database.Repositories.Implements;

public class BaseRepository<T>(ApplicationDbContext dbContext)
    : IBaseRepository<T> where T : Entity
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IQueryable<T> Entities => _dbContext.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        T exist = _dbContext.Set<T>().Find(entity.Id)
            ?? throw new NotFoundException(nameof(T), entity.Id);
        _dbContext.Entry(exist).CurrentValues.SetValues(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task SaveChangeAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    
}