using bookproject.Models;
using Microsoft.EntityFrameworkCore;

namespace bookproject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public ApplicationDbContext()
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding data
            modelBuilder.Entity<Book>().HasData(new Book {Id = 1,Title = "database", AuthorId = 1}, new Book { Id = 2,Title = "Linq", AuthorId = 2});

            modelBuilder.Entity<Author>().HasData(new Author { Id = 1,Name = "Mohamed Nasr" }, new Author { Id = 2,Name = "Ayman Nasr" });

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1,Name = "Dot Net" }); 
        }
    }
}
