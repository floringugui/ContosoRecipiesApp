using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.DAL
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DataContext dataContext) : base(dataContext)
        { }

        public async Task<IEnumerable<Ingredient>> GetByRecipeId(int id)
        {
            var ingredients = await _dataContext.Ingredients
                .Where(x => x.RecipeId == id)
                .ToListAsync();

            return ingredients;
        }
    }
}