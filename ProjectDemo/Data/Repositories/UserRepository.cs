using ProjectDemo.Contexts;
using ProjectDemo.Data.IRepositories;
using ProjectDemo.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemo.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DemoDbContext dbContext) : base(dbContext)
        {

        }

    }
}
