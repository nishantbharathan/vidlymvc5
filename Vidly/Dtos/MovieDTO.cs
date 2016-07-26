using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Dtos
{
    public class MovieDTO
    {

        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }
    }
}