using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class SupplierIngredientDTO:BaseSupplierDTO
    {
        public required string IngredientId { get; set; }
        public required string IngredientName { get; set; }
        public decimal PricePerKg { get; set; }
    }
}