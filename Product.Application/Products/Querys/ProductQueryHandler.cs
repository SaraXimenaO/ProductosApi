using MediatR;
using Products.Domain.Dtos;
using Products.Domain.Ports;

namespace Products.Application.Products.Querys
{
    public class ProductQueryHandler : IRequestHandler<ProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Product = await _productRepository.GetProductAsync(request.ProductId);
                return new ProductDto(
                    Product.ProductId, 
                    Product.Name, 
                    Product.Status.ToString(), 
                    Product.Stock, 
                    Product.Description, 
                    Product.Price, 
                    0, 
                    Product.Price 
                    );
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            
            }
        }
    }
}
