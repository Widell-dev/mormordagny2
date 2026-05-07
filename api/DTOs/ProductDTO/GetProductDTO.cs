using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.ProductDTO
{
    public class GetProductDTO:BaseProductDTO
    {
        public string Id { get; set; } = null!;
    }
}