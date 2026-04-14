using CleanArchitectureDemo.Application.Abstractions.Persistence;
using CleanArchitectureDemo.Domain.Products;
using MediatR;

namespace CleanArchitectureDemo.Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price, int Stock) : IRequest<Guid>;

public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Guid>
{
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price, request.Stock);
        
        await productRepository.AddAsync(product, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return product.Id;
    }
}