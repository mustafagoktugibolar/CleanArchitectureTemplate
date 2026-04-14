using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Persistence.Contexts;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}