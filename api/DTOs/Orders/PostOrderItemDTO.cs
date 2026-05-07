using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Orders
{
    public class PostOrderItemDTO
    {
        public required string ProductId { get; set; }
        public required int Quantity { get; set; }
    }
}