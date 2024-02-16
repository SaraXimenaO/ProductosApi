using AutoMapper;
using Products.Application.Products.Commands;
using Products.Domain.Entities;

namespace Products.Application.Products
{
    public class ProductPrifile: Profile
    {
        public ProductPrifile() 
        {
            CreateMap<ProductUpdateCommand, Product>();
        }
    }
}
