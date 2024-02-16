using Products.Domain.Ports;
using Products.Domain.Entities;
using Products.Infrastructure.Ports;

namespace Products.Infrastructure.Adapters;

public class ProductRepository : IProductRepository
{
    readonly IGenericRepository<Product> _genericRepository;

    public ProductRepository(IGenericRepository<Product> genericRepository)
    {
        _genericRepository = genericRepository;
    }


    public async Task<Product> AddAsync(Product product)
    {
        var result = await _genericRepository.AddAsync(product);
        _genericRepository.Save();
        return result;
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
