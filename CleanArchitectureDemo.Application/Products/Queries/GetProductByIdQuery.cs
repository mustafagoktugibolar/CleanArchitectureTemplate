using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Domain.Products;
using MediatR;

namespace CleanArchitectureDemo.Application.Products.Queries;

public record ProductDto(Guid Id, string Name, decimal Price);
public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto?>;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
         return await productRepository.GetByIdAsync(request.Id, cancellationToken) is Product product
            ? new ProductDto(product.Id, product.Name, product.Price)
            : null;
    }
}