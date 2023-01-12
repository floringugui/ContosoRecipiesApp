using ContosoRecipiesApi.DAL;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public RecipesController(DataContext dataContext)
        {
            _unitOfWork = new UnitOfWork(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes([FromQuery] int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException(nameof(count));
            }

            var recipes = await _unitOfWork.RecipeRepository.Get(includeProperties: "Directions,Ingredients");

            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(id);
            recipe.Directions = await _unitOfWork.DirectionRepository.GetByRecipeId(id);

            // TODO: Add the same logic for the ingredients similar to the directions logic in the previous line
            //recipe.Ingredients = await _unitOfWork.DirectionRepository.GetByRecipeId(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.RecipeRepository.Update(recipe);

            try
            {
                await _unitOfWork.Save();
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRecipe(int id, JsonPatchDocument<Recipe> recipeUpdates)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(id);
            if (recipe == null)
            {
                return BadRequest();
            }

            recipeUpdates.ApplyTo(recipe);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _unitOfWork.RecipeRepository.Insert(recipe);
            await _unitOfWork.Save();

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _unitOfWork.RecipeRepository.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> RecipeExists(int id)
        {
            return await _unitOfWork.RecipeRepository.Exists(id);
        }
    }
}