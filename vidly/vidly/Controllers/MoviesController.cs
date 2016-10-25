using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
           
            var movies = new List<Movie>
            {
                new Movie { Name = "Shrek!" },
                new Movie { Name = "Wall-e" },
                new Movie { Name = "Xablau!" }
            };
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

    }
}