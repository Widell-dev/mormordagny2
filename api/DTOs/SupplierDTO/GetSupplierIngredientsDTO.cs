using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class GetSupplierWithIngredientsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<SupplierIngredientDTO> Ingredients { get; set; }
    }

}