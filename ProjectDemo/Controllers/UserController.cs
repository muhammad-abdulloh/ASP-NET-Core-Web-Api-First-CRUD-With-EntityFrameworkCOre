using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Models;
using ProjectDemo.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectDemo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor include
        /// </summary>
        /// <param name="userService"></param>
        public UserController( IUserService userService) => _userService = userService;


        /// <summary>
        /// Create User account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public Task<User> Create(User user) => _userService.CreateAsync(user);


        /// <summary>
        /// Get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public Task<User> Get(long id) => _userService.GetAsync(p => p.Id == id);


        /// <summary>
        /// GetAll users
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public Task<IQueryable<User>> GetAll() => _userService.GetAllAsync();

        /// <summary>
        /// Delete by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("Delete")]
        public Task<bool> Delete(long id) => _userService.DeleteAsync(p => p.Id == id);


        /// <summary>
        /// Update user account
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPatch("Update")]
        public Task<User> Update (User user) => _userService.UpdateAsync(user);


    }
}
