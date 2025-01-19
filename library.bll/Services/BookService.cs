using AutoMapper;
using librar.data.Entities;
using librar.data.Repositories;
using library.bll.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.Services
{
    public class BookService : IBookService
    {
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            BookRepository = bookRepository;
            _mapper = mapper;
        }

        public IBookRepository BookRepository { get; }
        private readonly IMapper _mapper;

        public async Task<addBookDto> addBook(addBookDto book)
        {
            var newBook = _mapper.Map<Book>(book);
            var res = await BookRepository.addBook(newBook);

            return _mapper.Map<addBookDto>(book);

        }

        public async Task<bool> deleteBookById(int id)
        {
            var res = await BookRepository.deleteBookById(id);
            return res;

        }

        public async Task<IEnumerable<BookDto>> GetAllBooks()
        {
            var Books = await BookRepository.getaAllBooks();
            var BooksDto = new List<BookDto>();

            foreach (var book in Books)
            {
                BooksDto.Add(new BookDto
                {
                    BookId = book.BookId,
                    Name = book.Name,
                    Description = book.Description,
                    Price = book.Price,
                    Auther = book.Auther,
                    Stock = book.Stock,
                    CategoryId = book.CategoryId,
                    CatName = book.Category.Name,
                    CatDescription = book.Category.Description,
                });


            }
            return BooksDto;
        }

        public async Task<BookDto> getBookById(int id)
        {
            var book = await BookRepository.GetBook(id);

            BookDto bookdto = _mapper.Map<BookDto>(book);
            bookdto.CatName = book.Category.Name;
            bookdto.CatDescription = book.Category.Description;
            if (book == null)
            {
                // Handle not found case, e.g., throw an exception or return null
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            // Use AutoMapper to map Book to BookDto
            return bookdto;
        }

        public async Task<BookDto> updatBook(int id, addBookDto addBookDto)
        {

            Book book = await BookRepository.GetBook(id);
            book.Name = addBookDto.Name;
            book.Description = addBookDto.Description;
            book.Auther = addBookDto.Auther;
            book.Price = addBookDto.Price;
            book.Stock = addBookDto.Stock;
            book.CategoryId = addBookDto.CategoryId;

            var res = await BookRepository.updatBook(book);

            if (res == null)
            {
                return null; // Book not found or update failed
            }

            // Map the updated Book entity back to BookDto
            return _mapper.Map<BookDto>(res);
        }


        public async Task<IEnumerable<BookDto>> findByCat(string cat)
        {
            IEnumerable<Book> books = await BookRepository.findByCat(cat);
            IEnumerable<BookDto> booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            foreach (BookDto bookDto in booksDto)
            {
                bookDto.CatName = books.FirstOrDefault(x => x.BookId == bookDto.BookId).Category.Name;
                bookDto.CatDescription = books.FirstOrDefault(x => x.BookId == bookDto.BookId).Category.Description;
            }
            return booksDto;
        }

    }
}
