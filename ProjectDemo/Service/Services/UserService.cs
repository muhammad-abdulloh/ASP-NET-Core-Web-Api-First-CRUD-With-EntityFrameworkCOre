using ProjectDemo.Data.IRepositories;
using ProjectDemo.Models;
using ProjectDemo.Service.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemo.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateAsync(User entity)
        {
            return _userRepository.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepository.DeleteAsync(expression);
        }

        public Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            return _userRepository.GetAllAsync(expression);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepository.GetAsync(expression);
        }

        public Task<User> UpdateAsync(User entity)
        {
            return _userRepository.UpdateAsync(entity);
        }
    }
}
