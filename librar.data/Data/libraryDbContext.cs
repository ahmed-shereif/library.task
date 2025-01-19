using librar.data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librar.data.Data
{
    public class libraryDbContext : DbContext
    {
        public libraryDbContext(DbContextOptions<libraryDbContext> options)
    : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Fiction", Description = "Fictional Books" },
                new Category { CategoryId = 2, Name = "Science", Description = "Scientific Books" },
                new Category { CategoryId = 3, Name = "History", Description = "Historical Books" }
            );

            // Seed data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "The Great Gatsby",
                    Description = "A novel by F. Scott Fitzgerald",
                    Price = 10.99f,
                    Auther = "F. Scott Fitzgerald",
                    Stock = 100,
                    CategoryId = 1 // Fiction
                },
                new Book
                {
                    BookId = 2,
                    Name = "A Brief History of Time",
                    Description = "A book by Stephen Hawking",
                    Price = 15.50f,
                    Auther = "Stephen Hawking",
                    Stock = 50,
                    CategoryId = 2 // Science
                },
                new Book
                {
                    BookId = 3,
                    Name = "Sapiens",
                    Description = "A brief history of humankind",
                    Price = 20.00f,
                    Auther = "Yuval Noah Harari",
                    Stock = 75,
                    CategoryId = 3 // History
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    
    }
}