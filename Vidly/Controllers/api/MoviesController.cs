using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.App_Start;
using System.Data.Entity;
using Vidly.Dtos;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {

            _context = new ApplicationDbContext();
        }

        //GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m=>m.Genre)
                                     .ToList()
                                     .Select(Mapper.Map<Movie, MovieDTO>));

        }

        //GET api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));

        }

        

        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id  = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDTO.Id), movieDTO);

        }

        //PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDTO movieDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return NotFound();

            Mapper.Map(movieDTO, movie);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }



    }
}
