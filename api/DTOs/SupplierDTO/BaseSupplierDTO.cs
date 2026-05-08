using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class BaseSupplierDTO
    {
        public required string Id { get; set; }
        public required string SupplierName { get; set; }
    }
}