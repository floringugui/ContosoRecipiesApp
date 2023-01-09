using ContosoRecipiesApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ContosoRecipiesApi.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DataContext _dataContext;
        internal DbSet<TEntity> _dbSet;

        private bool _disposed = false;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Exists(object id)
        {
            return await GetById(id) != null;
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(object id)
        {
            TEntity entityToDelete = await GetById(id);
            await Delete(entityToDelete);
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (_dataContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual async Task Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dataContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual async Task Save()
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