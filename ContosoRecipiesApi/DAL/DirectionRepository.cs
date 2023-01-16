using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.DAL
{
    public class DirectionRepository : GenericRepository<Direction>, IDirectionRepository
    {
        public DirectionRepository(DataContext dataContext) : base(dataContext)
        { }

        public async Task<IEnumerable<Direction>> GetByRecipeId(int id)
        {
            var directions = await _dataContext.Directions
                .Where(x => x.RecipeId == id)
                .ToListAsync();

            return directions;
        }
    }
}