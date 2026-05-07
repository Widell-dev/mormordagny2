using core.Specifications;
using Core.Entities.Purchases;

namespace Core.Specifications
{
    public class SupplierIngredientSpecification : BaseSpecification<SupplierIngredient>
    {
        public SupplierIngredientSpecification(string ingredientId)
            : base(si => si.IngredientId == ingredientId)
        {
            AddInclude(si => si.Supplier);
            AddInclude(si => si.Ingredient);
        }

        public SupplierIngredientSpecification(string supplierId, bool bySupplier)
            : base(si => si.SupplierId == supplierId)
        {
            AddInclude(si => si.Supplier);
            AddInclude(si => si.Ingredient);
        }
    }
}