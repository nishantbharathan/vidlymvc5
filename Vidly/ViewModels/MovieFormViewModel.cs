using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;
namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }      

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }


        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }



        public string Title
        {

            get
            {

                if (Id!=null)
                    return "Edit Movie";

                return "New Movie";
            }
        }

        public MovieFormViewModel()
        {

            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            Name = movie.Name;

        }
    }
}