using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Orders
{
    public class GetOrderItemDTO
    {
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required decimal SubTotal { get; set; }
    }
}