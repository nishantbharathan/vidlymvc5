using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {

            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDTO rentaldto)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == rentaldto.CustomerId );

            if (customer == null) return BadRequest("Invalid Customer Id - Customer not found ");

            var movies = _context.Movies.Where(m => rentaldto.MovieIds.Contains(m.Id)).ToList();

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now             
                };

                _context.Rentals.Add(rental);


            }

            _context.SaveChanges();

            return Ok();

        }

    }

}
