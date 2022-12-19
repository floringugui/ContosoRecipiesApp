using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateRecipes()
        {
            // Create logic => return true / ok
            var successfullyCreated = true;

            if(!successfullyCreated)
            {
                return BadRequest();
            }

            return Created("[controller]", new object());
        }
                
        
        [HttpGet]
        public ActionResult GetRecipes()
        {
            string[] recipes = { "recipe1", "recipe2" };            
            // Get recipes

            if(recipes == null)
            {
                return NotFound();
            }
            
            return Ok(recipes);
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

            if(!successfullyUpdated)
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
