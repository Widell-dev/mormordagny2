using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Purchases;
using Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.Specifications;
using api.DTOs.SupplierDTO;

namespace api.Controllers
{
    public class SuppliersController(IGenericRepository<Supplier> repo, IMapper map) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllSuppliers()
        {
            var spec = new SupplierSpecification();
            var suppliers = await repo.ListAsync(spec);
            var result = map.Map<IReadOnlyList<GetSupplierWithIngredientsDTO>>(suppliers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSupplierById(string id)
        {
            var spec = new SupplierByIdSpecification(id);
            var supplier = await repo.FindAsync(spec);
            if (supplier == null) return NotFound();
            var result = map.Map<GetSupplierWithIngredientsDTO>(supplier);
            return Ok(result);
        }

        [HttpPost("{supplierId}/ingredients")]
        public async Task<ActionResult> AddIngredientToSupplier(string supplierId, PostSupplierIngredientDTO dto)
        {
            try
            {
                var supplier = await repo.FindByIdAsync(supplierId);
                if (supplier == null) return NotFound("Supplier not found");

                var newIngredient = new SupplierIngredient
                {
                    SupplierId = supplierId,
                    IngredientId = dto.IngredientId,
                    PricePerKg = dto.PricePerKg
                };


                supplier.SupplierIngredients.Add(newIngredient);
                repo.Update(supplier);
                if (await repo.SaveAllAsync()) return StatusCode(201);

                return BadRequest("Server error");
            }
            catch
            {
                return BadRequest("Server error");
            }
        }

        [HttpPut("{supplierId}/ingredients/{ingredientId}")]
        public async Task<ActionResult> UpdateSupplierIngredient(string supplierId, string ingredientId, PutSupplierIngredientDTO dto)
        {
            try
            {
                var supplier = await repo.FindByIdAsync(supplierId);
                if (supplier == null) return NotFound("Supplier not found");

                var ingredient = supplier.SupplierIngredients.FirstOrDefault(i => i.IngredientId == ingredientId);
                if (ingredient == null) return NotFound("Ingredient not found for this supplier");

                ingredient.PricePerKg = dto.PricePerKg;

                repo.Update(supplier);
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