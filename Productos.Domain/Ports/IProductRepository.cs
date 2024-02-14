using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Ports
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        void UpdateAsync(Product product);
        Task<Product> GetProductAsync(int id);
    }
}
