using librar.data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.DTOs
{
    public class BookDto
    {

        public int BookId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    
        public float Price { get; set; }
        public string Auther { get; set; }

        public int Stock { get; set; }

        public int? CategoryId { get; set; }

        public string CatName { get; set; }
 
        public string CatDescription { get; set; }


    }
}
