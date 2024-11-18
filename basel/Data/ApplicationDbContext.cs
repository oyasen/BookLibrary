using basel.Models;
using Microsoft.EntityFrameworkCore;

namespace basel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(x => x.Authors).WithMany(x => x.Books);
            modelBuilder.Entity<Book>().HasMany(x => x.Genres).WithMany(x => x.Books);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Auhtors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
