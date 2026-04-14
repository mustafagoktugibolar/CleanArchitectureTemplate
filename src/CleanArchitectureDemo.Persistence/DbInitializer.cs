using CleanArchitectureDemo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Persistence;

public static class DbInitializer
{
    public static void ApplyMigrations(AppDbContext context)
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}