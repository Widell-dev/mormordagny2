using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Orders
{
    public class PostOrderDTO
    {
        public required string CustomerId { get; set; }
        public required List<PostOrderItemDTO> Items { get; set; }
    }
}