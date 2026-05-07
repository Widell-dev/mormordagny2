using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.ProductDTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ProductsController(IGenericRepository<Product> repo, IMapper mapper) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] ProductSpecificationParams args)
        {
            var spec = new ProductSpecification(args);
            var products = await repo.ListAsync(spec);
            var result = mapper.Map<IReadOnlyList<GetProductDTO>>(products);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(string id)
        {
            var spec = new ProductSpecification(id);
            var product = await repo.FindAsync(spec);

            if (product is null) return NotFound();

            var result = mapper.Map<GetProductDTO>(product);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(PostProductDTO model)
        {
            try
            {
                var product = mapper.Map<Product>(model);

                repo.Add(product);
                if (await repo.SaveAllAsync()) return StatusCode(201);

                return BadRequest("Server error");
                
            }
            catch 
            {
                return BadRequest("Server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateProduct(string id, PatchProductDTO model)
        {
            try
            {
                var spec = new ProductSpecification(id);
                var product = await repo.FindAsync(spec);

                if (product is null) return NotFound();

                mapper.Map(model, product);
                repo.Update(product);
                if (await repo.SaveAllAsync()) return NoContent();

                return BadRequest("Server error");
            }
            catch
            {
                return BadRequest("Server error");
            }
        }
    }
}