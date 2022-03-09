using Microsoft.EntityFrameworkCore;
using ProjectDemo.Contexts;
using ProjectDemo.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#pragma warning disable
namespace ProjectDemo.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        /// <summary>
        /// Connect dbContext
        /// </summary>
        private DemoDbContext _dbContext;
        private DbSet<T> _dbSet;

        /// <summary>
        /// Connect Base
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericRepository(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }


        /// <summary>
        /// Create Generic 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            if (entity == null) 
                return false;

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// GetAll Generic value
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
            => expression == null ? _dbSet : _dbSet.Where(expression);

        /// <summary>
        /// Get by Id item
        /// </summary>  
        /// <param name="expression"></param>
        /// <returns></returns>
        public  Task<T> GetAsync(Expression<Func<T, bool>> expression) => _dbSet.FirstOrDefaultAsync(expression);


        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}

#pragma warning restore