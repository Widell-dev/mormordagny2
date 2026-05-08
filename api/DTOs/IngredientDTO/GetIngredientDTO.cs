using api.DTOs.SupplierDTO;

namespace api.DTOs.IngredientDTO
{
    public class GetIngredientDTO:BaseIngredientDTO
    {
        public required string ItemNumber { get; set; }
        public List<SupplierIngredientDTO> Suppliers { get; set; } = new();
    }
}