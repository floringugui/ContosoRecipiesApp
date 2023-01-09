using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoRecipiesApi.DAL
{
    public class RecipeRepository : IRecipeRepository, IDisposable
    {
        private DataContext _dataContext;
        private bool _disposed = false;

        public RecipeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Recipe> GetRecipeById(int recipeId)
        {
            var recipe = await _dataContext.Recipes
                .FindAsync(recipeId);

            return recipe;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _dataContext.Recipes
                .Include(x => x.Directions)
                .Include(x => x.Ingredients)
                .ToListAsync();
        }

        public async Task<bool> RecipeExists(int recipeId)
        {
            return await _dataContext.Recipes
                .AnyAsync(x => x.Id == recipeId);
        }

        public async Task InsertRecipe(Recipe recipe)
        {
            await _dataContext.Recipes.AddAsync(recipe);
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _dataContext.Recipes.Attach(recipe);
            _dataContext.Entry(recipe).State = EntityState.Modified;

            //var recipeEntity = await GetRecipeById(recipe.Id);

            //recipeEntity.Title = recipeEntity.Title;
            //recipeEntity.Description = recipeEntity.Description;
            //recipeEntity.Updated = DateTime.Now;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = await GetRecipeById(recipeId);

            _dataContext.Recipes.Remove(recipe);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}