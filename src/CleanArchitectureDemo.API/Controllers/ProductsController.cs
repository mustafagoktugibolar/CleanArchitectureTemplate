using CleanArchitectureDemo.Application.Products.Commands;
using CleanArchitectureDemo.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return Ok(new { id = productId });   
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        if (product is null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
}