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
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieFormrmViewModel = new MoviesFormViewModel
            {
                Genres = genres
            };
            return View("MoviesForm",movieFormrmViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id != 0)
            {
                var movieIndb = _context.Movies.Single(m=>m.Id == movie.Id);
                movieIndb.Name = movie.Name;
                movieIndb.ReleaseDate = movie.ReleaseDate;
                movieIndb.NumberInStock = movie.NumberInStock;
                movieIndb.GenreId = movie.GenreId;
            }
            else
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movieIndb = _context.Movies.Include("Genre").SingleOrDefault(m => m.Id == Id);
            
            var movieFormViewModel = new MoviesFormViewModel
            {
                Movie = movieIndb,
                Genres = _context.Genres.ToList()

            };
            return View("MoviesForm", movieFormViewModel);
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include("Genre");
            return View(movies);
        }
        public ActionResult Random()
        {
            var moviesList = _context.Movies;

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

        //public ActionResult Edit(int? movieId)
        //{
        //    if (!movieId.HasValue)
        //    {
        //        movieId = 1;
        //    }
        //    return Content("Id=" + movieId.Value);
        //}

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        [Route("movies/released/{year:regex(2015|2016)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDates(int year, int month)
        {
            return Content(year + "/" + month);
        }
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include("Genre").SingleOrDefault(cus => cus.Id == Id);

            if (movie is null)
                return HttpNotFound();

            return View(movie);


        }
    }
}