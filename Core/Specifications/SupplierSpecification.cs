using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Specifications;
using Core.Entities.Purchases;

namespace Core.Specifications
{
    public class SupplierSpecification:BaseSpecification<Supplier>
    {
        public SupplierSpecification()
        {
            AddInclude(s => s.SupplierIngredients);
            AddInclude("SupplierIngredients.Ingredient");
        }
    }

    public class SupplierByIdSpecification : BaseSpecification<Supplier>
    {
        public SupplierByIdSpecification(string id) : base(s=> s.Id == id)
        {
            AddInclude(s => s.SupplierIngredients);
            AddInclude("SupplierIngredients.Ingredient");
        }
    }


}