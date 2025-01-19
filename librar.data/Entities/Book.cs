using librar.data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;


//1) Design Entities:
//2) Relationships and Constraints: (use any SQL DB )
//3) Data Validation:
//4) API Endpoints:
//-GET / api / book: Retrieve a list of all books.
//- GET /api/book/{id}: Retrieve a specic book by ID.
//- POST /api/book: Add a new book.
//- PUT / api / book /{ id}: Update an existing book.
//- DELETE /api/book/{id}: Delete a book.
//Upskilling Task
//Book (BookId, Name, Description, Price, Auther, stock)
//Category ( CategoryId, Name, Description )
//One-to-Many Relationship: A category can have multiple Books
namespace librar.data.Entities
{
    public class Book
    {
        public int BookId{ get; set; }
   
        public string Name{ get; set; }
 
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public float Price { get; set; }
        public string Auther { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public  int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
