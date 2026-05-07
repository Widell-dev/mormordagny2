using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Orders;

namespace api.DTOs.CustomerDTO
{
    public class GetCustomerByIdDTO : BaseCustomerDTO
    {
        public string Id { get; set; } = null!;
        public AddressDTO DeliveryAddress { get; set; } = null!;
        public AddressDTO InvoiceAddress { get; set; } = null!;
        public List<OrderSumDTO> Orders { get; set; } = [];

    }
}