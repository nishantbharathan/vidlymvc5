using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
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

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();

            var MovieFormViewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),                
            };

            return View("MovieForm", MovieFormViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var MovieFormViewModel = new MovieFormViewModel(movie)
                {               
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", MovieFormViewModel);

            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
           
                var MovieinDb = _context.Movies.Single(m => m.Id == movie.Id);
                MovieinDb.Name = movie.Name;
                MovieinDb.NumberInStock = movie.NumberInStock;
                MovieinDb.GenreId = movie.GenreId;
                MovieinDb.ReleaseDate = movie.ReleaseDate;
            }


            _context.SaveChanges();
       
            
            return RedirectToAction("Index", "Movies");

        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var MovieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),                
            };

            return View("MovieForm",MovieFormViewModel);
            
        }

        //[OutputCache(Duration=50,Location=System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre);
        }


        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return new HttpNotFoundResult();

            return View(movie);
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