using Products.Domain.Ports;
using Products.Domain.Entities;
using Products.Infrastructure.Ports;

namespace Products.Infrastructure.Adapters.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductRepository(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public Task<Product> AddAsync(Product product)
        {
            return _genericRepository.AddAsync(product);
        }

        public void UpdateAsync(Product product)
        {
            _genericRepository.UpdateAsync(product);
        }

        public Task<Product> GetProductAsync(int id)
        {
            return _genericRepository.GetByIdAsync(id);
        }
    }
}
