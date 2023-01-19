using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public interface IUnitOfWork
    {
        public IRecipeRepository RecipeRepository { get; }
        public IDirectionRepository DirectionRepository { get; }
        public IIngredientRepository IngredientRepository { get; }

        public Task Save();
    }
}