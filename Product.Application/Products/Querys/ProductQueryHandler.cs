using MediatR;
using Products.Application.Products.Commands;
using Products.Domain.Dtos;
using Products.Domain.Ports;

namespace Products.Application.Products.Querys
{
    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductStatusCache _productStatusCache;
        private readonly IResponseTimeLogger _responseTimeLogger;

        public ProductQueryHandler(IProductRepository productRepository, IProductStatusCache productStatusCache, IResponseTimeLogger responseTimeLogger)
        {
            _productRepository = productRepository;
            _productStatusCache = productStatusCache;
            _responseTimeLogger = responseTimeLogger;
        }

        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            DateTime requestTime = DateTime.Now;
            var productStatusDictionary = _productStatusCache.GetProductStatusDictionary();
            var Product = await _productRepository.GetProductAsync(request.ProductId);
            string statusName = productStatusDictionary.TryGetValue((int)Product.Status, out string name) ? name : "Inactive";

            _responseTimeLogger.LogResponseTime(requestTime, nameof(ProductQuery));

            return new ProductDto(
                Product.ProductId,
                Product.Name,
                statusName,
                Product.Stock,
                Product.Description,
                Product.Price,
                0,
                Product.Price
            );
        }

    }
}


