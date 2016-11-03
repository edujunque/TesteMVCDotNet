using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;
using System.Data.Entity;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           

            var viewModel = new IndexCustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);

        }

        [Route("customer/details/{customerID}")]
        public ActionResult Details(int customerID)
        {

            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == customerID);

            return View(customers);

        }
    }
}