using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using vidly.Models;
using vidly.ViewModel;
using System.Data.Entity;

namespace vidly.Controllers
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

        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var viewModel = new IndexMovieViewModel()
            {
                Movies = movies,
              
            };
            return View(viewModel);

        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("olá mundão");
            //return HttpNotFound();
            //return new EmptyResult();

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);

            //return RedirectToAction("Index", "Home", new {Page = 1, sortBy = "name"});

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

       

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies/details/{movieId}")]
        public ActionResult Details(int movieID)
        {

            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == movieID);

            return View(movies);

        }

    }
}