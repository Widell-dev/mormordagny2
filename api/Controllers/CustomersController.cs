using api.DTOs.CustomerDTO;
using AutoMapper;
using Core.Entities;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;



namespace api.Controllers
{
    public class CustomerController(IGenericRepository<Customer> repo, IMapper mapper) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var spec = new CustomerSpecification();
            var customers = await repo.ListAsync(spec);
            var result = mapper.Map<IReadOnlyList<DTOs.CustomerDTO.GetCustomerDTO>>(customers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(string id)
        {
            var spec = new CustomerWithOrdersSpecification(id);
            var customer = await repo.FindAsync(spec);

            if (customer is null) return NotFound();

            var result = mapper.Map<GetCustomerByIdDTO>(customer);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(PostCustomerDTO model)
        {
            try
            {
                var customer = mapper.Map<Customer>(model);

                repo.Add(customer);
                if (await repo.SaveAllAsync()) return StatusCode(201);

                return BadRequest("Server error");
                
            }
            catch 
            {
                return BadRequest("Server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCustomer(string id, PatchCustomerDTO model)
        {
            var customer = await repo.FindByIdAsync(id);
            if (customer is null) return NotFound();

            mapper.Map(model, customer);
            if (await repo.SaveAllAsync()) return NoContent();

            return BadRequest("Server error");
        }
    }
}