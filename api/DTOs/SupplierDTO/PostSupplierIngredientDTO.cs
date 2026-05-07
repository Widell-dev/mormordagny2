using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class PostSupplierIngredientDTO
    {
        public string IngredientId { get; set; }
        public decimal PricePerKg { get; set; }

    }
}