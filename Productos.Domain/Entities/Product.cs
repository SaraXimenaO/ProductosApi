using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class Product : DomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
