using Microsoft.EntityFrameworkCore;
namespace WebApi.Entities
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options){}

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Brand> brands { get; set; }
    }
}
