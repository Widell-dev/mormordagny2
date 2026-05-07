using api.DTOs.Orders;
using AutoMapper;
using Core.Entities;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class OrdersController(
        IGenericRepository<Order> OrderRepo,
        IGenericRepository<Product> ProductRepo,
        IGenericRepository<Customer> CustomerRepo,
        IMapper mapper) : ApiBaseController
    {
        [HttpPost]
        public async Task<ActionResult> CreateOrder(PostOrderDTO dto)
        {
            try
            {
                var customer = await CustomerRepo.FindByIdAsync(dto.CustomerId);
                if (customer == null)
                    return BadRequest("Customer not found");

                var order = new Order
                {
                    CustomerId = dto.CustomerId,
                    OrderDate = DateTime.Now,
                    OrderNumber = Guid.NewGuid().ToString().Substring(0, 5),
                    OrderItems = new List<OrderItem>()
                };
                foreach (var item in dto.Items)
                {
                    var product = await ProductRepo.FindByIdAsync(item.ProductId);
                    if (product == null)
                        return BadRequest($"Product with id {item.ProductId} not found");

                    order.OrderItems.Add(new OrderItem
                    {
                        Quantity = item.Quantity,
                        Price = product.PricePerUnit,
                        ItemOrdered = new ItemOrdered
                        {
                            ProductId = product.Id,
                            ProductName = product.ProductName
                        }
                    });

                }
                OrderRepo.Add(order);
                var result = await OrderRepo.SaveAllAsync();
                if (!result) return BadRequest("Problem creating order");
                return Ok(order.Id);
            }
            catch (Exception)
            {
                return BadRequest("Server error");

            }
        }

        [HttpGet()]
        public async Task<ActionResult> GetOrders([FromQuery] OrderSpecificationParams args)
        {
            var spec = new OrderSpecification(args);
            var orders = await OrderRepo.ListAsync(spec);
            
            var result = mapper.Map<IReadOnlyList<GetOrdersDTO>>(orders);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(string id)
        {
            var spec = new OrderSpecification(id);
            var order = await OrderRepo.FindAsync(spec);
            if (order == null) return NotFound();

            var result = mapper.Map<GetOrdersDTO>(order);
            return Ok(result);
        }
    }
}