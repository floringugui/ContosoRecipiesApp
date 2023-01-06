using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();

        Task<Recipe> GetRecipeById(int recipeId);

        Task<bool> RecipeExists(int recipeId);

        Task InsertRecipe(Recipe recipe);

        Task DeleteRecipe(int recipeId);

        Task UpdateRecipe(Recipe recipe);

        Task Save();
    }
}