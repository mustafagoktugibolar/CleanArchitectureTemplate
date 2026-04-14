using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Persistence.Repositories;


public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();   
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    { 
        return await GetQueryable().ToListAsync(cancellationToken);
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }
}