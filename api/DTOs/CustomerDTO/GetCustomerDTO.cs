using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CustomerDTO
{
    public class GetCustomerDTO: BaseCustomerDTO
    {
        public string Id { get; set; } = null!;

    }
}