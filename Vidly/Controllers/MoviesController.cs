using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        List<Movie> moviesList = new List<Movie> {
            new Movie{Id= 1,Name = "Shrink!" },
            new Movie{Id= 2,Name = "Wall E!" }

        };


        public ActionResult Index()
        {
            var ViewModel = new MoviesViewModel
            {
                Movies = moviesList
            };
            return View(ViewModel);
        }
        public ActionResult Random()
        {
            var customers = new List<Customer>
            {
                new Customer{ Id=1, Name = "Customer 1"},
                new Customer{ Id=2, Name = "Customer 2"}
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = moviesList.FirstOrDefault(),
                customers = customers

            };

            return
              View(ViewModel);
            // Content("Hello Whorld!");
            //HttpNotFound();
            // new EmptyResult();
            //RedirectToAction("Index", "Home", new { page = 1, shortby = "name" });
        }

        public ActionResult Edit(int? movieId)
        {
            if (!movieId.HasValue)
            {
                movieId = 1;
            }
            return Content("Id=" + movieId.Value);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        [Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDates(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}