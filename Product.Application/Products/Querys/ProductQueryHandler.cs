using MediatR;
using Products.Domain.Dtos;
using Products.Domain.Ports;

namespace Products.Application.Products.Querys
{
    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductStatusCache _productStatusCache;

        public ProductQueryHandler(IProductRepository productRepository, IProductStatusCache productStatusCache)
        {
            _productRepository = productRepository;
            _productStatusCache = productStatusCache;
        }

        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            var productStatusDictionary = _productStatusCache.GetProductStatusDictionary();
            var Product = await _productRepository.GetProductAsync(request.ProductId);
            string statusName = productStatusDictionary.TryGetValue((int)Product.Status, out string name) ? name : "Desconocido";

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


