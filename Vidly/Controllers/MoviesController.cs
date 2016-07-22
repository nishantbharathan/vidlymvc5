using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels; 


namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{


        public ActionResult Index()
        {

            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {

                new Movie(){Id="1",Name="Tridev"},
                new Movie(){Id="2",Name="Trimurti"}

            };

        }



		//
		// GET: /Movies/
		public ActionResult Random()
		{

			Movie movie = new Movie() { Name = "Agonypath" };

			var Customers = new List<Customer>
			{
				new Customer() { Name="Ronaldo"},
				new Customer() { Name ="Messi"}
			};

			var RandomViewModel = new RandomMovieViewModel()
			{
				Movies = movie,
				Customers = Customers
			};


            return View(RandomViewModel);


			//return View(movie);
			//return RedirectToAction("Index", "Home",new {Page = 1,SortBy= "name"});
			//return new EmptyResult();

		}

		[Route("movies/released/{year}/{month}")]
		public ActionResult MovieByRelease(int year,int month)
		{
			return Content(String.Format("Year: {0},Month : {1}", year, month));
		}
	}
}