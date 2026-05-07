using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.IngredientDTO;
using AutoMapper;
using Core.Entities.Purchases;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class IngredientsController(IGenericRepository<Ingredient> repo, IMapper map) : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllIngredients([FromQuery] IngredientSpecificationParams args)
        {
            var ingredients = new IngredientSpecification(args);
            var ingredient = await repo.ListAsync(ingredients);
            var result = map.Map<IReadOnlyList<GetIngredientDTO>>(ingredient);

            return Ok(result);
        }
    
       [HttpGet("{id}")]
        public async Task<ActionResult> GetIngredient(string id)
        {
            var ingredient = new IngredientSpecification(id);
            var result = await repo.FindAsync(ingredient);

            if (result == null) return NotFound();

            return Ok(map.Map<GetIngredientDTO>(result));
        }

        [HttpPost]
        public async Task<ActionResult> AddIngredient(PostIngredientDTO model)
        {
            try
            {
                var ingredient = map.Map<Ingredient>(model);
                repo.Add(ingredient);
                if (await repo.SaveAllAsync()) return StatusCode(201);

                return BadRequest("Server error");
            }
            catch
            {
                return BadRequest("Server error");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateIngredient(string id, PutIngredientDTO model)
        {
            try
            {
                var ingredient = await repo.FindByIdAsync(id);
                if (ingredient == null) return NotFound();

                map.Map(model, ingredient);
                repo.Update(ingredient);
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
