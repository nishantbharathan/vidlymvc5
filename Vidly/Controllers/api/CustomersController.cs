using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;


namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        
        }

        //GET api/customers
        [HttpGet]
        public IHttpActionResult  GetCustomers()
        {

            return Ok(_context.Customers.Include(c=>c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>));
        }


        //GET api/customers/1
        [HttpGet]
        public IHttpActionResult  GetCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return NotFound();
                

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));

        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.ID = customer.ID;
            return Created(new Uri(Request.RequestUri + "/" + customer.ID),customerDTO);
        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return BadRequest();
            var customerinDB = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerinDB == null) return NotFound();


            Mapper.Map(customerDTO, customerinDB);
            
            _context.SaveChanges();

            return Ok();
            
        }

        //DELET api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerinDB = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerinDB == null) return NotFound();

            _context.Customers.Remove(customerinDB);
            _context.SaveChanges();

            return Ok();

        }

    }
}
