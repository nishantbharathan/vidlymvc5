using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
		  _context = new ApplicationDbContext();
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