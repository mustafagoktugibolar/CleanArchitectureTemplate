using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Domain.Products;
using CleanArchitectureDemo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
{
}