using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModel;

namespace vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer { Name = "Dudy",Id = 1},
                new Customer { Name = "John", Id = 2 },
                new Customer { Name = "Mcgaiver", Id = 3 }
            };

            var viewModel = new IndexCustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);

        }

        [Route("customer/details/{customerID}")]
        public ActionResult Details(int customerID)
        {

            var customers = new List<Customer>
            {
                new Customer { Name = "Dudy",Id = 1},
                new Customer { Name = "John", Id = 2 },
                new Customer { Name = "Mcgaiver", Id = 3 }
            };

            var model = new Customer
            {
                Name = customers.Find(c => c.Id == customerID).Name
            };

            return View(model);

        }
    }
}