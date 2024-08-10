using Lms.DataAccessLayer.Abstract;
using Lms.DataAccessLayer.EntityFrameworkCores.Contexts;
using Lms.Entity.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lms.DataAccessLayer.EntityFrameworkCores.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly LmsContext _dbContext;

        protected DbSet<T> TableEntity => _dbContext.Set<T>();
        public GenericRepository(LmsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(T entity)
        {
            var addedState = await TableEntity.AddAsync(entity);
            return addedState.State == EntityState.Added;
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            if (tracking is false)
            {
                return await TableEntity.AsNoTracking().ToListAsync();
            }
            return await TableEntity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await TableEntity.FindAsync(id);

        public  IQueryable<T> GetWhereAsync(Expression<Func<T, bool>> expression)
            =>  TableEntity.Where(expression);

        public bool Remove(T entity)
        {
            var removed = TableEntity.Remove(entity);
            return removed.State == EntityState.Deleted;
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
