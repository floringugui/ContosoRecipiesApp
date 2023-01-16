using System.Linq.Expressions;

namespace ContosoRecipiesApi.DAL
{
    public interface IGenericRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        public Task<TEntity> GetById(object id);

        public Task<bool> Exists(object id);

        public Task Insert(TEntity entity);

        public Task Delete(TEntity entityToDelete);

        public Task Delete(object id);

        public Task Update(TEntity entityToUpdate);

        public Task Save();
    }
}