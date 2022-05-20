using Ispit.Books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Mike Tyson" },
                new Author { Id = 2, Name = "Marin Držić" }, 
                new Author { Id = 3, Name = "Mirko Miočić" }, 
                new Author { Id = 4, Name = "Fernando Magellan" },
                new Author { Id = 5, Name = "Ivana Brlić Mažuranić" }
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher {Id = 1, Name = "KIF" }, 
                new Publisher { Id = 2, Name = "Zlatna knjiga" },
                new Publisher { Id = 3, Name = "Algoritam" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}