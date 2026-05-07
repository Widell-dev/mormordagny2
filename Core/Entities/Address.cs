using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Address
    {
        public required string AddressLine { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
        public Address(){}
    }
}