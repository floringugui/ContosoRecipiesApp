using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext dataContext) : base(dataContext)
        { }
    }
}