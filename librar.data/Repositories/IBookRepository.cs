using librar.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librar.data.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> getaAllBooks();
        public Task<Book>   GetBook(int id);
 
        public Task<Book> addBook(Book book);
        public Task<Book> updatBook(Book book);
        public Task<bool> deleteBookById(int id);
        public Task<IEnumerable<Book>> findByCat(string cat);
    }
}
