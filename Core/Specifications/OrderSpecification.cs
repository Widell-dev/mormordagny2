using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Specifications;
using Core.Entities.Orders;

namespace Core.Specifications
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(string id)
            : base(o => o.Id == id)
        {
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);
            AddInclude("OrderItems.ItemOrdered");
            AddInclude("OrderItems.ItemOrdered.Product");

        }

        public OrderSpecification(OrderSpecificationParams args)
        : base(o =>
            (string.IsNullOrEmpty(args.OrderNumber) || o.OrderNumber == args.OrderNumber) &&
            (!args.Date.HasValue || o.OrderDate.Date == args.Date.Value.Date)
        )
        {
            AddInclude(o => o.Customer);
            AddInclude(o => o.OrderItems);
            AddInclude("OrderItems.ItemOrdered");
            AddInclude("OrderItems.ItemOrdered.Product");

            ApplyPagination(args.PageSize, args.PageSize * (args.PageNumber - 1));
            UseOrderByDescending(o => o.OrderDate);
        }
    }
}
