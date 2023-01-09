using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using ContosoRecipiesApi.DAL;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly GenericRepository<Ingredient> _ingredientRepository;

        public IngredientsController(DataContext context)
        {
            _ingredientRepository = new GenericRepository<Ingredient>(context);
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetDirections()
        {
            var ingredients = await _ingredientRepository.Get();

            if (ingredients == null)
            {
                return NotFound();
            }
            return Ok(ingredients);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            _ingredientRepository.Update(ingredient);

            try
            {
                await _ingredientRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            await _ingredientRepository.Insert(ingredient);
            await _ingredientRepository.Save();

            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _ingredientRepository.Delete(id);
            await _ingredientRepository.Save();

            return NoContent();
        }

        private async Task<bool> IngredientExists(int id)
        {
            return await _ingredientRepository.Exists(id);
        }
    }
}