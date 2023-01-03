using ContosoRecipiesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldRecipeController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateRecipes([FromBody] Recipe newRecipe)
        {
            // Create logic => return true /  ok
            var successfullyCreated = true;

            if (!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", newRecipe);
        }

        [HttpGet]
        public ActionResult GetRecipes([FromQuery] int count)
        {
            Recipe[] recipes =
            {
                new() {Title = "Recipe1", Description = "Recipe1 description"},
                new() {Title = "Recipe2", Description = "Recipe1 description"},
                new() {Title = "Recipe3", Description = "Recipe1 description"},
            };

            // Get recipes
            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes.Take(count));
        }

        [HttpDelete("{id}")] // api/Recipe/50
        public ActionResult DeleteRecipes(int id)
        {
            // Delete logic => return true / ok
            var successfullyDeleted = true;

            if (!successfullyDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("entire/{id}")]
        public ActionResult UpdateEntireRecipes(int id)
        {
            // Update logic - entire entity / object / model
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("partial/{id}")]
        public ActionResult UpdatePartialRecipes(int id)
        {
            // Update logic - needed field / properites for the entity / object / model
            var successfullyUpdated = true;

            if (!successfullyUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}