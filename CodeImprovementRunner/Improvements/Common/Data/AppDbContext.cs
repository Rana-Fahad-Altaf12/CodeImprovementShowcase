using Microsoft.EntityFrameworkCore;
using Improvements.Common.Models;

namespace Improvements.Common.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
