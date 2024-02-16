using Microsoft.Extensions.Caching.Memory;
using Products.Domain.Ports;

namespace Products.Infrastructure.Adapters;

public class ProductStatusCache: IProductStatusCache
{
    private readonly IMemoryCache _cache;

    public ProductStatusCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Dictionary<int, string> GetProductStatusDictionary()
    {
        if (!_cache.TryGetValue("ProductStatusDictionary", out Dictionary<int, string> productStatusDictionary))
        {
            productStatusDictionary = LoadProductStatusDictionaryFromDataSource();
            _cache.Set("ProductStatusDictionary", productStatusDictionary, TimeSpan.FromMinutes(5));
        }

        return productStatusDictionary;
    }

    private Dictionary<int, string> LoadProductStatusDictionaryFromDataSource()
    {
        return new Dictionary<int, string>
        {
            { 1, "Active" },
            { 0, "Inactive" }
        };
    }
}
