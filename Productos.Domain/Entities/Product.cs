using Products.Domain.Enums;
using Throw;

namespace Products.Domain.Entities
{
    public class Product : DomainEntity
    {
        private string _name;

        public Product(string name, string description, Status status, int stock, decimal price ) 
        {
            Name = name;
            Description = description;
            Status = status;
            Stock = stock;
            Price = price;
        }

        public string Name { get => _name; set => value.ThrowIfNull().IfEmpty(); }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
