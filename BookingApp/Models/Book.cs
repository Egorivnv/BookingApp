using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Book
    { 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required (ErrorMessage ="Please enter an author") ]
        public string Author { get; set; }
        [Required (ErrorMessage ="Please enter price")]
        //[RegularExpression(@"\d+",ErrorMessage ="Not correct format")] - ?? работает не правильно
        public int Price { get; set; }

    }
}