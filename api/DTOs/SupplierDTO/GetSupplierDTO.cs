namespace api.DTOs.SupplierDTO
{
    public class GetSupplierDTO
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string ContactPerson { get; set; }
    }
}