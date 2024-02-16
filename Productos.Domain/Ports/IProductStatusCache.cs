using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Ports;

public interface IProductStatusCache
{
    Dictionary<int, string> GetProductStatusDictionary();
}
