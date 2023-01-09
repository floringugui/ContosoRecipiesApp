using ContosoRecipiesApi.DAL;
using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private readonly GenericRepository<Direction> _directionRepository;

        public DirectionsController(DataContext context)
        {
            _directionRepository = new GenericRepository<Direction>(context);
        }

        // GET: api/Directions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> GetDirections()
        {
            var directions = await _directionRepository.Get();

            if (directions == null)
            {
                return NotFound();
            }

            return Ok(directions);
        }

        // GET: api/Directions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direction>> GetDirection(int id)
        {
            var direction = await _directionRepository.GetById(id);

            if (direction == null)
            {
                return NotFound();
            }

            return Ok(direction);
        }

        // PUT: api/Directions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirection(int id, Direction direction)
        {
            if (id != direction.Id)
            {
                return BadRequest();
            }

            await _directionRepository.Update(direction);

            try
            {
                await _directionRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DirectionExists(id))
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

        // POST: api/Directions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direction>> PostDirection(Direction direction)
        {
            await _directionRepository.Insert(direction);
            await _directionRepository.Save();

            return CreatedAtAction("GetDirection", new { id = direction.Id }, direction);
        }

        // DELETE: api/Directions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirection(int id)
        {
            await _directionRepository.Delete(id);
            await _directionRepository.Save();

            return NoContent();
        }

        private async Task<bool> DirectionExists(int id)
        {
            return await _directionRepository.Exists(id);
        }
    }
}