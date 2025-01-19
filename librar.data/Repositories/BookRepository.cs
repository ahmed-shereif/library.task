using librar.data.Data;
using librar.data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace librar.data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(libraryDbContext libraryDbCont)
        {
            LibraryDbCont = libraryDbCont;
        }

        public libraryDbContext LibraryDbCont { get; }

        public async Task<Book> addBook(Book book)
        {
            var result = await LibraryDbCont.Books.AddAsync(book);
            await LibraryDbCont.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> deleteBookById(int id)
        {
            var result = await LibraryDbCont.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (result != null)
            {
                LibraryDbCont.Books.Remove(result);
                await LibraryDbCont.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Book>> getaAllBooks()
        {

            var books = await LibraryDbCont.Books
                               .Include(b => b.Category) // Load the Category navigation property
                               .ToListAsync();


            return books;

        }

        public async Task<Book> GetBook(int id)
        {
            var result = await LibraryDbCont.Books.Include(b => b.Category).FirstOrDefaultAsync(b => b.BookId == id);
            if (result != null)
            {

                return result;
            }
            return null;
        }

        public async Task<Book> updatBook(Book book)
        {
            var updatedBook = await LibraryDbCont.Books.FirstOrDefaultAsync(b => b.BookId == book.BookId);
            if (updatedBook != null)
            {

                updatedBook.Name = book.Name;
                updatedBook.Description = book.Description;
                updatedBook.Auther = book.Auther;
                updatedBook.Price = book.Price;
                updatedBook.Stock = book.Stock;
                updatedBook.CategoryId = book.CategoryId;


                await LibraryDbCont.SaveChangesAsync();

                return updatedBook;
            }
            return null;

        }

        public async Task<IEnumerable<Book>> findByCat(string cat)
        {
            if (cat != null)
            {

                List<Book> books = await LibraryDbCont.Books.Include(e => e.Category).Where(b => b.Category.Name == cat).ToListAsync();
                return books;
            }
            return new List<Book>(); ;
        }

    }
}
