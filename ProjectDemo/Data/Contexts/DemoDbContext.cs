using Microsoft.EntityFrameworkCore;
using ProjectDemo.Models;

namespace ProjectDemo.Contexts
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
            
        }

        public DemoDbContext()
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
