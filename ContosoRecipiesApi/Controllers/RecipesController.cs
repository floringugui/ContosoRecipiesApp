using ContosoRecipiesApi.DAL;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Return a list of all the recipes - changed
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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