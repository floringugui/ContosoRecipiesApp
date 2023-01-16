using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        public Task<IEnumerable<Ingredient>> GetByRecipeId(int id);
    }
}