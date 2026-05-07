using Core.Entities;

namespace api.DTOs.CustomerDTO
{
    public class BaseCustomerDTO
    {
        public string CompanyName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ContactPerson { get; set; }

    }
}