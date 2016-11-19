using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Movie Name")]
        public string MovieName { get; set; }

        public Genre Genre { get; set; }     //navigation property to make genre dataset as well as using include t connect to its tables.

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Date Of Release")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }
    }
}