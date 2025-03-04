using MediatorR.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorR.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
       public DbSet<Users> Users { get; set; }
    }
}
