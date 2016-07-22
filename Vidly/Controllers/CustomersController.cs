using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models; 

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Index()               
        {
            var Customers = GetCustomers();
            return View(Customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return new HttpNotFoundResult();

            return View(customer);

        }

        private IEnumerable<Customer> GetCustomers()
        {

            return new List<Customer>
            {

                new Customer() {ID=1,Name="Sachin"},
                new Customer() {ID=2,Name="Rohit"}
            };
        }
	}
}