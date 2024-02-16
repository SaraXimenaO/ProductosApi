using MediatR;
using Products.Domain.Entities;
using Products.Domain.Enums;
using Products.Domain.Ports;

namespace Products.Application.Products.Commands;

public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, Product>
{
    private readonly IProductRepository _productRepository;
    private readonly IResponseTimeLogger _responseTimeLogger;

    public ProductInsertCommandHandler(IProductRepository productRepository, IResponseTimeLogger responseTimeLogger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _responseTimeLogger = responseTimeLogger ?? throw new ArgumentNullException(nameof(responseTimeLogger));
    }



    public async Task<Product> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
    {
        
        DateTime requestTime = DateTime.Now;
        if (request is null) throw new ArgumentNullException(nameof(request));
        var product = await _productRepository.AddAsync(new Product(
            request.Name,
            request.Description,
            Status.Active,
            request.Stock,
            request.Price
            ));
        TimeSpan responseTime = DateTime.Now - requestTime;

        _responseTimeLogger.LogResponseTime(requestTime, responseTime, nameof(ProductInsertCommand));
        
        return product;
    }
}
