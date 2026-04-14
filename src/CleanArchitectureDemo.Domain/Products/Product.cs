namespace CleanArchitectureDemo.Domain.Products;

public class Product(string name, decimal price, int stock)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public decimal Price { get; private set; } = price;
    public int Stock { get; private set; } = stock;
}