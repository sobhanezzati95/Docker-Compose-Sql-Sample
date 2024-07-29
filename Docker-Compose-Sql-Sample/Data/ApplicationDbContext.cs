using Docker_Compose_Sql_Sample.Entity;
using Microsoft.EntityFrameworkCore;

namespace Docker_Compose_Sql_Sample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) :
            base(dbContextOptions)
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Demo> Demos { get; set; }
    }
}
