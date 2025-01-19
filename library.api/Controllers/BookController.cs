using librar.data.Entities;
using library.bll.DTOs;
using library.bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace library.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        public BookController(IBookService bookService)
        {
            BookService = bookService;
        }

        public IBookService BookService { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await BookService.GetAllBooks();
            return Ok(books.ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> getBookById(int id)
        {
            try
            {
                var book = await BookService.getBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return book;

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<addBookDto>> AddBook([FromBody] addBookDto bookDto)
        {
            // Validate the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }
            try
            {
                // Attempt to add the book
                var addedBook = await BookService.addBook(bookDto);
                // Return the added book with a Created (201) status
                return CreatedAtAction(nameof(AddBook), addedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);


            }


       

   
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] addBookDto updatedBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var book = await BookService.updatBook(id, updatedBookDto);
            if(book == null)
            {
                return StatusCode(500, "An error occurred while saving the book.");

            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteBookById(int id)
        {
           bool res= await BookService.deleteBookById(id);
            if (res==true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "An error occurred while saving the book.");

            }
        }

        [HttpGet("getByCat/{category}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> getByCategory(string category)
        {
            if(category != null)
            {
                IEnumerable<BookDto> books =  await BookService.findByCat(category);
                return Ok(books);

            }
            return BadRequest();
        }

    }
}
