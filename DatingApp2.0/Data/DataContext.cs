using DatingApp2._0.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp2._0.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
