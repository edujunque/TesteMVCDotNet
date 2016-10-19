using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using vidly.Models;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            //return View(movie);
            //return Content("olá mundão");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new {Page = 1, sortBy = "name"});

        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy{1}", pageIndex, sortBy));

        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/"+ month);
        }

    }
}