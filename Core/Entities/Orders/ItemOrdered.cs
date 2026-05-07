using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Orders
{
    public class ItemOrdered
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
    }
}