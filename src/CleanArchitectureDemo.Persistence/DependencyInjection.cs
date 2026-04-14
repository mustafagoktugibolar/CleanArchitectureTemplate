using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Persistence.Contexts;
using CleanArchitectureDemo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDemo.Persistence;

public static class DependencyInjection
{
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            // other dbs here 
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
    
            return services;
        }
}