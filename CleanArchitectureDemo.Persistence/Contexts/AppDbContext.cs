using CleanArchitectureDemo.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}