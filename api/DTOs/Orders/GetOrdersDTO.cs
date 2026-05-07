using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Orders
{
    public class GetOrdersDTO
    {
        public string Id { get; set; } = null!;
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public List<GetOrderItemDTO> Items { get; set; } = null!;
        public decimal SubTotal { get; set; }
    }
}