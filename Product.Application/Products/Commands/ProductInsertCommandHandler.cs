using MediatR;
using Products.Domain.Entities;
using Products.Domain.Enums;
using Products.Domain.Ports;

namespace Products.Application.Products.Commands;

public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductInsertCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    } 
       
    

    public async Task<Product> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        var product = await _productRepository.AddAsync(new Product(
            request.Name, 
            request.Description, 
            Status.Active, 
            request.Stock, 
            request.Price
            ));
        return product;
    }
}
