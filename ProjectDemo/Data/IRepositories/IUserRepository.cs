using ProjectDemo.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDemo.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
