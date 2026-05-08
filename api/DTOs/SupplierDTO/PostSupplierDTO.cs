using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class PostSupplierDTO
    {
        public required string Name { get; set; }
        public string? Address { get; set; }
        public required string ContactPerson { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
    }
}