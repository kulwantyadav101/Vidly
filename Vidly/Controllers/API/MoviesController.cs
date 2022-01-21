using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET   /api/Movies
        public IHttpActionResult GetMovie()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET   /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies is null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movies));
        }

        // POST api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/Movies/1
        [HttpPut]
        public void UpdateCustomer(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(cus => cus.Id == id);
            if (movieInDb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges(); 

        }

        // DELETE api/Movies/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerIndb = _context.Movies.SingleOrDefault(cus => cus.Id == id);
            if (customerIndb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(customerIndb);
            _context.SaveChanges();

        }
    }
}
