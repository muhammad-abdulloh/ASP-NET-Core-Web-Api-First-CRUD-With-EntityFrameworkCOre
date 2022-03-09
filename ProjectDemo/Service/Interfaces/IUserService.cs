using ProjectDemo.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemo.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(User entity);
        Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);

    }
}
