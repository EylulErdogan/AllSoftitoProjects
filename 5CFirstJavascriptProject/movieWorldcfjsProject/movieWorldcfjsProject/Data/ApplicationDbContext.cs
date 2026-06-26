
using Microsoft.EntityFrameworkCore;
using movieWorldcfjsProject.Models;

namespace movieWorldcfjsProject.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
