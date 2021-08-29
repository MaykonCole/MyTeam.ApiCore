using Microsoft.EntityFrameworkCore;
using MyTeam.Core.Models;

namespace MyTeam.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}

