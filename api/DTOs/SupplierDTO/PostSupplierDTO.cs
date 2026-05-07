using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.SupplierDTO
{
    public class PostSupplierDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}