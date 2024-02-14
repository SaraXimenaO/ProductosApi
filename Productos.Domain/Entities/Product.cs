using Products.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class Product : DomainEntity
    {

        public Product(string name, string description, Status status, int stock, decimal price ) 
        {
            Name = name;
            Description = description;
            Status = status;
            Stock = stock;
            Price = price;
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
