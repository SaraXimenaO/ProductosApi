using Products.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Throw;

namespace Products.Domain.Entities;

public class Product : DomainEntity
{
    private string _name;

    public Product()
    {
    }

    public Product(string name, string description, Status status, int stock, decimal price ) 
    {
        Name = name;
        Description = description;
        Status = status;
        Stock = stock;
        Price = price;
    }

    public int? ProductId { get; set; }
    public string Name { get => _name; set => _name = value.ThrowIfNull().IfEmpty(); }
    public string Description { get; set; }
    public Status Status { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }

    public decimal calculateDiscountPrice(int discount)
    {
        return Price * (100 - discount) / 100;
    }
}
