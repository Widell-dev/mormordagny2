using api.DTOs;
namespace api.DTOs.CustomerDTO
{
    public class PostCustomerDTO : BaseCustomerDTO
    {
    public AddressDTO DeliveryAddress { get; set; } = null!;
    public AddressDTO InvoiceAddress { get; set; } = null!;

    }
}