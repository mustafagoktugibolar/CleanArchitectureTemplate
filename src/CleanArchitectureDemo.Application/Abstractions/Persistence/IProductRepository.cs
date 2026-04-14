using CleanArchitectureDemo.Domain.Products;

namespace CleanArchitectureDemo.Application.Abstractions.Persistence;

public interface IProductRepository : IRepository<Product>
{
    // product specific methods can be added here
}