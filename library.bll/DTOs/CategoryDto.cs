using librar.data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
        //public virtual List<Book> Book { get; set; }
    }
}
