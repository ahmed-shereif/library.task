using librar.data.Entities;
using library.bll.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



//-GET / api / book: Retrieve a list of all books.
//- GET /api/book/{id}: Retrieve a specic book by ID.
//- POST /api/book: Add a new book.
//- PUT / api / book /{ id}: Update an existing book.
//- DELETE /api/book/{id}: Delete a book
namespace library.bll.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetAllBooks();
        public Task<BookDto> getBookById(int id);
        public Task<addBookDto> addBook(addBookDto book);
        public Task<BookDto> updatBook(int id, addBookDto book);
        public Task<bool> deleteBookById(int id);

        public Task<IEnumerable<BookDto>> findByCat(string cat);

    }
}
