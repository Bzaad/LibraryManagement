using Microsoft.EntityFrameworkCore;
using CoreBusiness;

namespace Plugins.DataStore.SQL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", Description = "Fiction Books" },
                new Category { Id = 2, Name = "Non-fiction", Description = "None-fiction Books" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, CategoryId = 1, Name = "A Farewell to Arms", Description = "Novel by Ernest Hemingway", AvailableCopies = 4 },
                new Book { Id = 2, CategoryId = 1, Name = "The Hitchhiker's Guide to the Galaxy", Description = "Novel by Douglas Adams", AvailableCopies = 3 },
                new Book { Id = 3, CategoryId = 1, Name = "One Hundred Years of Solitude", Description = "Novel by Gabriel García Marquez", AvailableCopies = 5 },
                new Book { Id = 4, CategoryId = 2, Name = "The Language Instinct", Description = "Book by Steven Pinker", AvailableCopies = 2 },
                new Book { Id = 5, CategoryId = 2, Name = "A Brief History of Time", Description = "Book by Stephen Hawking", AvailableCopies = 2 },
                new Book { Id = 6, CategoryId = 2, Name = "Guns, Germs, and Steel", Description = "Book by  Jared Diamond", AvailableCopies = 1 }
            );
        }
    }
}
