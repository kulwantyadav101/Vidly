using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET   /api/Customers
        public IHttpActionResult  GetCustomer()
        {
            return Ok(_context.Customers
                    .Include(cus => cus.MembershipType)
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>)) ;
        }

        // GET   /api/Customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers                            
                            .SingleOrDefault(cus => cus.Id == id);
            if(customer is null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id= customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT api/Customers/1
        [HttpPut]
        public void  UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(cus => cus.Id == id);
            if(customerInDb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto,customerInDb);
            _context.SaveChanges();

        }

        // DELETE api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerIndb = _context.Customers.SingleOrDefault(cus => cus.Id == id);
            if (customerIndb is null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerIndb);
            _context.SaveChanges();

        }

    }
}
