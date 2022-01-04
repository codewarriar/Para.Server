using Microsoft.EntityFrameworkCore;
using Para.Shared;

namespace Para.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Stories> UserStories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStory> UsersStory { get; set; }

    }
}
