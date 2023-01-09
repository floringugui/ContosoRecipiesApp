using ContosoRecipiesApi.DAL;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly GenericRepository<Recipe> _recipeRepository;

        public RecipesController(DataContext dataContext)
        {
            _recipeRepository = new GenericRepository<Recipe>(dataContext);
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeRepository.Get(includeProperties: "Directions,Ingredients");

            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _recipeRepository.GetById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _recipeRepository.Update(recipe);

            try
            {
                await _recipeRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RecipeExists(id))
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

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _recipeRepository.Insert(recipe);
            await _recipeRepository.Save();

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _recipeRepository.Delete(id);
            await _recipeRepository.Save();

            return NoContent();
        }

        private async Task<bool> RecipeExists(int id)
        {
            return await _recipeRepository.Exists(id);
        }
    }
}