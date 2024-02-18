using MediatR;
using Products.Application.Products.Commands;
using Products.Domain.Dtos;
using Products.Domain.Entities;
using Products.Domain.Ports;
using Products.Infrastructure.Adapters;

namespace Products.Application.Products.Querys
{
    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductStatusCache _productStatusCache;
        private readonly IResponseTimeLogger _responseTimeLogger;
        private readonly DiscountService _discountService;

        public ProductQueryHandler(
            IProductRepository productRepository, 
            IProductStatusCache productStatusCache, 
            IResponseTimeLogger responseTimeLogger, 
            DiscountService discountService
            )
        {
            _productRepository = productRepository;
            _productStatusCache = productStatusCache;
            _responseTimeLogger = responseTimeLogger;
            _discountService = discountService;
        }

        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            DateTime requestTime = DateTime.Now;
            var productStatusDictionary = _productStatusCache.GetProductStatusDictionary();
            Product Product = await _productRepository.GetProductAsync(request.ProductId);
            DiscountResponse discountResponse = await _discountService.GetDiscountAsync(request.ProductId);
            string statusName = productStatusDictionary.TryGetValue((int)Product.Status, out string name) ? name : "Inactive";

            _responseTimeLogger.LogResponseTime(requestTime, nameof(ProductQuery));

            return new ProductDto(
                Product.ProductId,
                Product.Name,
                statusName,
                Product.Stock,
                Product.Description,
                Product.Price,
                discountResponse.Discount,
                Product.calculateDiscountPrice(discountResponse.Discount)
            ) ;
        }

    }
}


