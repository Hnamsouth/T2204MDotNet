using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ExamSEM3.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) :base(options){
        }

        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>()
                .HasIndex(c => c.ContactName)
                .IsUnique();
        }
       
    }
}
