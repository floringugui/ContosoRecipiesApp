using ContosoRecipiesApi.Models;

namespace ContosoRecipiesApi.DAL
{
    public interface IDirectionRepository : IGenericRepository<Direction>
    {
        public Task<IEnumerable<Direction>> GetByRecipeId(int id);
    }
}