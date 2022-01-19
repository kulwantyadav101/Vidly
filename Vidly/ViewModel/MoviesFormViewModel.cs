using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }        

        [Required]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "Number of stock should be between 1 to 20")]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New Movie"; }
        }

        public MoviesFormViewModel()
        {
            Id = 0;
        }
        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }

    }
}