using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
		  _context = new ApplicationDbContext();
		}

		public ActionResult New()
		{
			var CustomerFormViewModel = new CustomerFormViewModel()
			{
				MemberShipTypes = _context.MemberShipTypes.ToList()
			};

			return View("CustomerForm",CustomerFormViewModel);
		}

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null) { return HttpNotFound(); }

            var CustomerFormViewModel = new CustomerFormViewModel()
            {

                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", CustomerFormViewModel);

        }

		[HttpPost]
		public ActionResult Save(Customer customer)
		{

            if(customer.ID==0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.ID == customer.ID);

                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }

			
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}
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
			return _context.Customers.Include(c => c.MemberShipType);
		}
	}
}