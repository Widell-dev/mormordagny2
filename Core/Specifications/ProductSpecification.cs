using core.Specifications;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecificationParams args)
        : base(c =>
            string.IsNullOrEmpty(args.Search) ||
            c.ProductName.ToLower().Contains(args.Search.ToLower())
        )
    {
    
        ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));

        switch (args.Sort)
        {
            case "priceAsc":
                UseOrderByAscending(c => c.PricePerUnit);
                break;

            case "priceDesc":
                UseOrderByDescending(c => c.PricePerUnit);
                break;

            default:
                UseOrderByAscending(c => c.ProductName);
                break;
        }
    }

    public ProductSpecification(string id)
        : base(c => c.Id == id)
    {
        
    }
}