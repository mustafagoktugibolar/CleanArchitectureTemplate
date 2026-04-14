using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Domain.Products;
using MediatR;

namespace CleanArchitectureDemo.Application.Products.Queries;

public record GetProductsQuery : IRequest<List<Product>>;

public class GetProductsQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetAllAsync(cancellationToken);
    }
}