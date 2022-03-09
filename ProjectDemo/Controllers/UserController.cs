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

        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public Task<User> Create(User user)
        {
            return _userService.CreateAsync(user);
        }

        [HttpGet("{id}")]
        public Task<User> Get(long id)
        {
            return _userService.GetAsync(p => p.Id == id);
        }


        [HttpGet("All")]
        public Task<IQueryable<User>> GetAll()
        {
            return _userService.GetAllAsync();
        } 


        [HttpDelete("Delete")]
        public Task<bool> Delete(long id)
        {
            return _userService.DeleteAsync(p => p.Id == id);
        }
        
        [HttpPatch("Update")]
        public Task<User> Update (User user)
        {
            return _userService.UpdateAsync(user);
        }



    }
}
