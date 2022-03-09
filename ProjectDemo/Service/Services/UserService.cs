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


        /// <summary>
        /// Include Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository ) => _userRepository = userRepository;


        /// <summary>
        /// Create user values
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<User> CreateAsync(User entity) => _userRepository.CreateAsync(entity);


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression) => _userRepository.DeleteAsync(expression);


        /// <summary>
        /// Get All users
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null) => _userRepository.GetAllAsync(expression);


        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<User> GetAsync(Expression<Func<User, bool>> expression) => _userRepository.GetAsync(expression);


        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<User> UpdateAsync(User entity) => _userRepository.UpdateAsync(entity);
    }
}
