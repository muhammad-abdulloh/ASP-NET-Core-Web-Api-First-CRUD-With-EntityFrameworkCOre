using Microsoft.EntityFrameworkCore;
using ProjectDemo.Contexts;
using ProjectDemo.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemo.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private DemoDbContext _dbContext;
        private DbSet<T> _dbSet;
        public GenericRepository(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            if (entity == null) 
                return false;

            _dbSet.Remove(entity);

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _dbSet : _dbSet.Where(expression);
        }

        public  Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return  _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
