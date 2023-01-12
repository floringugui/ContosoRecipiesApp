using ContosoRecipiesApi.Data;
using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _dataContext;
        private GenericRepository<Recipe> _recipeRepository;
        private IDirectionRepository _directionRepository;
        private GenericRepository<Ingredient> _ingredientRepository;

        private bool _disposed = false;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public GenericRepository<Recipe> RecipeRepository
        {
            get
            {
                if (_recipeRepository == null)
                {
                    _recipeRepository = new GenericRepository<Recipe>(_dataContext);
                }

                return _recipeRepository;
            }
        }

        public IDirectionRepository DirectionRepository
        {
            get
            {
                if (_directionRepository == null)
                {
                    _directionRepository = new DirectionRepository(_dataContext);
                }

                return _directionRepository;
            }
        }

        public GenericRepository<Ingredient> IngredientRepository
        {
            get
            {
                if (_ingredientRepository == null)
                {
                    _ingredientRepository = new GenericRepository<Ingredient>(_dataContext);
                }

                return _ingredientRepository;
            }
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}