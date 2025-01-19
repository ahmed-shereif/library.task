using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.bll.DTOs
{
    public class addBookDto
    {

        public string Name { get; set; }

        public string Description { get; set; }


        [Range(0, int.MaxValue)]
        public float Price { get; set; }
        public string Auther { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public int? CategoryId { get; set; }
    }
}
