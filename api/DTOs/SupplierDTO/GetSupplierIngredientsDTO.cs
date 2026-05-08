using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class GetSupplierWithIngredientsDTO
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string ContactPerson { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public List<SupplierIngredientDTO> Ingredients { get; set; } = new();
    }

}