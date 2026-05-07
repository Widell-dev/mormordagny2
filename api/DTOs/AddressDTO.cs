using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class AddressDTO
    {
        public required string AddressLine { get; set; } = string.Empty;
        public required string PostalCode { get; set; } = string.Empty;
        public required string City { get; set; } = string.Empty;

    }
}