using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.ProductDTO
{
    public class BaseProductDTO
    {
        public required string ProductName { get; set; }
        public required decimal PricePerUnit { get; set; }
        public required decimal ProductWeight { get; set; }
        public required string QuantityPerPackage { get; set; }
        public required DateTime BestBefore { get; set; }
        public required DateTime ProductionDate { get; set; }
    }
}